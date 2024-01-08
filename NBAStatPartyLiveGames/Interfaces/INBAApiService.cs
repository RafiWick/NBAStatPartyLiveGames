using NBAStatParty.Models.SR_Standings;
using NBAStatPartyLiveGames.Models.SRDailySchedule;
using NBAStatPartyLiveGames.Models.SRPlayByPlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Interfaces
{
    public interface INBAApiService
    {
        Task<SR_DailySchedule> GetDailySchedule(int year, int month, int day);
        Task<SR_PlayByPlay> GetPlayByPlay(string id);
        Task<SR_Standings> GetStandings();
    }
}
