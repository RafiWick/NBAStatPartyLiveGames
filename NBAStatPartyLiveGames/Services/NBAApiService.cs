using NBAStatParty.Models.SR_Standings;
using NBAStatPartyLiveGames.Interfaces;
using NBAStatPartyLiveGames.Models.SRDailySchedule;
using NBAStatPartyLiveGames.Models.SRPlayByPlay;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Services
{
    internal class NBAApiService : INBAApiService
    {
        private readonly HttpClient _client;
        public NBAApiService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("NBAAPI");
        }

        public async Task<SR_DailySchedule> GetDailySchedule(int year, int month, int day)
        {
            var url = string.Format("/nba/trial/v8/en/games/{0}/{1}/{2}/schedule.json?api_key={3}", year, month, day, Environment.GetEnvironmentVariable("NBA_SPORTRADAR_API_KEY", EnvironmentVariableTarget.User));
            var result = new SR_DailySchedule();

            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<SR_DailySchedule>(stringResponse);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return result;
        }
        public async Task<SR_PlayByPlay> GetPlayByPlay(string id)
        {
            var url = string.Format("/nba/trial/v8/en/games/{0}/pbp.json?api_key={1}", id, Environment.GetEnvironmentVariable("NBA_SPORTRADAR_API_KEY", EnvironmentVariableTarget.User));
            var result = new SR_PlayByPlay();

            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<SR_PlayByPlay>(stringResponse);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return result;
        }
        public async Task<SR_Standings> GetStandings()
        {
            var url = string.Format("/nba/trial/v8/en/seasons/2023/REG/standings.json?api_key={0}", Environment.GetEnvironmentVariable("NBA_SPORTRADAR_API_KEY", EnvironmentVariableTarget.User));
            var result = new SR_Standings();

            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<SR_Standings>(stringResponse);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return result;
        }
    }
}
