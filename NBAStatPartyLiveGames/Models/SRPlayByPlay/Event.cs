using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Models.SRPlayByPlay
{
    public class Event
    {
        public string Id { get; set; }
        public string Clock { get; set; }
        public DateTime Updated { get; set; }
        public string Description { get; set; }
        public DateTime Wall_Clock { get; set; }
        public long Sequence { get; set; }
        public int Home_Points { get; set; }
        public int Away_Points { get; set; }
        public string Clock_Decimal { get; set; }
        public int Number { get; set; }
        public string Event_Type { get; set; }
        public Attribution Attribution { get; set; }
        public Location? Location { get; set; }
        public Possession? Possession { get; set; }
        public OnCourt On_Court { get; set; }
        public List<Statistic> Statistics { get; set; }
    }
}
