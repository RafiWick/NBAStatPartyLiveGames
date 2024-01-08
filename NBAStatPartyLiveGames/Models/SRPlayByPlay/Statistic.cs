using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Models.SRPlayByPlay
{
    public class Statistic
    {
        public string Type { get; set; }
        public PTeam Team { get; set; }
        public Player Player { get; set; }
        public bool? Made { get; set; }
        public string? Shot_Type { get; set; }
        public string? Shot_Type_Desc { get; set; }
        public int? Points { get; set; }
        public double? Shot_Distance { get; set; }
        public string? Rebound_Type { get; set; }
        public string? Free_Throw_Type { get; set; }
        public bool? Three_Point_Shot { get; set; }
    }
}
