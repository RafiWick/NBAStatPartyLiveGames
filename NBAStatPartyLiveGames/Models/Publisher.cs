using NBAStatParty.Models.SR_Standings;
using NBAStatPartyLiveGames.Models.SRDailySchedule;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Models
{
    public class Publisher
    {
        public IDatabase _db { get; set; }
        
        public List<string> Teams { get; set; } = new List<string>();
        public Dictionary<string, string> Channels { get; set; } = new Dictionary<string, string>();
        
        public Publisher(SR_Standings standings, IDatabase db)
        {
            _db = db;
            // get each team and create a channel name
            foreach(var conference in standings.Conferences)
            {
                foreach(var division in conference.Divisions)
                {
                    foreach(var team in division.Teams)
                    {
                        Teams.Add(team.Id);
                        Channels.Add(team.Id, "streams:liveGames:team:" + team.Id);
                    }
                }
            }
            // Purge streams
            db.KeyDelete(Channels.Values.Select(k => new RedisKey(k)).ToArray());
        }

        public async Task<bool> GameStart(Game game)
        {
            await _db.StreamAddAsync(Channels[game.Home.Id], new[]
            {
                new NameValueEntry("id", game.Id),
                new NameValueEntry("channel", "streams:liveGames:game:" + game.Id),
                new NameValueEntry("status", "inprogress")
            });
            await _db.StreamAddAsync(Channels[game.Away.Id], new[]
            {
                new NameValueEntry("id", game.Id),
                new NameValueEntry("channel", "streams:liveGames:game:" + game.Id),
                new NameValueEntry("status", "inprogress")
            });

            return true;
        }
        public async Task<bool> GameStop(Game game)
        {
            await _db.StreamAddAsync(Channels[game.Home.Id], new[]
            {
                new NameValueEntry("id", game.Id),
                new NameValueEntry("channel", "streams:liveGames:game:" + game.Id),
                new NameValueEntry("status", "final")
            });
            await _db.StreamAddAsync(Channels[game.Away.Id], new[]
            {
                new NameValueEntry("id", game.Id),
                new NameValueEntry("channel", "streams:liveGames:game:" + game.Id),
                new NameValueEntry("status", "final")
            });

            return true;
        }
    }
}
