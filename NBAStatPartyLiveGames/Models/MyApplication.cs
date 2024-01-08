using Microsoft.Extensions.Logging;
using NBAStatParty.Models.SR_Standings;
using NBAStatPartyLiveGames.Interfaces;
using NBAStatPartyLiveGames.Models.SRDailySchedule;
using NBAStatPartyLiveGames.Models.SRPlayByPlay;
using NBAStatPartyLiveGames.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Models
{
    public class MyApplication
    {

        private readonly INBAApiService _NBAApiService;
        public MyApplication(IHttpClientFactory httpFactory)
        {
            _NBAApiService = new NBAApiService(httpFactory);
        }

        public async Task<SR_DailySchedule> GetDailySchedule(int year, int month, int day)
        {
            var response = await _NBAApiService.GetDailySchedule(year, month, day);
            return response;
        }
        public async Task<SR_PlayByPlay> GetPlayByPlay(string id)
        {
            var response = await _NBAApiService.GetPlayByPlay(id);
            return response;
        }
        public async Task<SR_Standings> GetStandings()
        {
            var response = await _NBAApiService.GetStandings();
            return response;
        }
    }
}
