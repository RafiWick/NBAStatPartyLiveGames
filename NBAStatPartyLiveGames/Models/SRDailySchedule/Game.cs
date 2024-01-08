using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Models.SRDailySchedule
{
    public class Game
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Coverage { get; set; }
        public DateTime Scheduled { get; set; }
        public int? Home_Points { get; set; }
        public int? Away_Points { get; set; }
        public bool Track_On_Court { get; set; }
        public string Sr_Id { get; set; }
        public string Reference { get; set; }
        public List<TimeZone> TimeZones { get; set; }
        public Venue Venue { get; set; }
        public List<Broadcast> Broadcasts { get; set; }
        public Team Home { get; set; }
        public Team Away { get; set; }






    }
}
