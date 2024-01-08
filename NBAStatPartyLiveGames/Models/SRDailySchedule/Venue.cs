using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Models.SRDailySchedule
{
    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Sr_Id { get; set; }
        public Location Location { get; set; }
    }
}
