using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Models.SRPlayByPlay
{
    public class Scoring
    {
        public int Times_Tied { get; set; }
        public int LeadChanges { get; set; }
        public PTeam Home { get; set; }
        public PTeam Away { get; set; }

    }
}
