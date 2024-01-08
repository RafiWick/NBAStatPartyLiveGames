using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NBAStatParty.Models.SR_Standings;
using NBAStatPartyLiveGames.Models;
using NBAStatPartyLiveGames.Models.SRDailySchedule;
using NBAStatPartyLiveGames.Models.SRPlayByPlay;
using StackExchange.Redis;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
        {
            services.AddHttpClient("NBAAPI", c => c.BaseAddress = new Uri("http://api.sportradar.us"));
            services.AddTransient<MyApplication>();
        }).UseConsoleLifetime();
        var host = builder.Build();
        using (var serviceScope = host.Services.CreateScope())
        {
            var options = new ConfigurationOptions
            {
                EndPoints = { Environment.GetEnvironmentVariable("REDIS_ENDPOINT", EnvironmentVariableTarget.User) },
                User = "default",
                Password = Environment.GetEnvironmentVariable("REDIS_PASSWORD", EnvironmentVariableTarget.User),
                AbortOnConnectFail = false
            };

            // initalize a multiplexer with ConnectionMultiplexer.Connect()
            var muxer = ConnectionMultiplexer.Connect(options);

            // get an IDatabase here with GetDatabase
            var db = muxer.GetDatabase();
            var services = serviceScope.ServiceProvider;
            var todaysSchedule = new SR_DailySchedule();
            var upcomingGames = new List<Game>();
            var liveGames = new List<Game>();
            var finalGames = new List<Game>();
            var standings = new SR_Standings();
            try
            {
                var myService = services.GetRequiredService<MyApplication>();
                standings = await myService.GetStandings();
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured");
            }
            var publisher = new Publisher(standings, db);
            while (true)
            {
                var today = $"{DateTime.Now.Year}-{DateTime.Now.Month:00}-{DateTime.Now.Day:00}";
                // get daily schedule
                if (todaysSchedule.Date != today)
                {
                    try
                    {
                        var myService = services.GetRequiredService<MyApplication>();
                        todaysSchedule = await myService.GetDailySchedule(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        upcomingGames = todaysSchedule.Games.Where(g => g.Status == "scheduled").ToList();
                        liveGames = todaysSchedule.Games.Where(g => g.Status == "inprogress").ToList();
                        finalGames = todaysSchedule.Games.Where(g => g.Status == "closed").ToList();
                        await Task.Delay(1000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Occured");
                    }
                }
                
                // move upcoming games to live games
                foreach(Game game in upcomingGames)
                {
                    if (game.Scheduled <= DateTime.UtcNow)
                    {
                        liveGames.Add(game);
                        upcomingGames.Remove(game);
                        publisher.GameStart(game);
                    }
                }

                // get play by play for each live game
                bool first = true;
                foreach(Game game in liveGames)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        await Task.Delay(15000);
                    }
                    var playByPlay = new SR_PlayByPlay();
                    try
                    {
                        var myService = services.GetRequiredService<MyApplication>();
                        playByPlay = await myService.GetPlayByPlay(game.Id);

                        if (playByPlay.Status == "closed")
                        {
                            finalGames.Add(game);
                            finalGames.Remove(game);
                            publisher.GameStop(game);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Occured");
                    }
                }

                await Task.Delay(15000);
            }
        }

        return 0;
    }
}