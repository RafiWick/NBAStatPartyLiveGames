using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Models.SRPlayByPlay
{
    public class Period
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public int Number { get; set; }
        public int Sequence { get; set; }
        public Scoring Scoring { get; set; }
        public List<Event> Events { get; set; }


    }
}
