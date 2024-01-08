using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Models.SRDailySchedule
{
    public class SR_DailySchedule
    {
        public string Date { get; set; }
        public League League { get; set; }
        public List<Game> Games { get; set; }
    }
}
