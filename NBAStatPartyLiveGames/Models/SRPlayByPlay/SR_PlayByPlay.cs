using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Models.SRPlayByPlay
{
    public class SR_PlayByPlay
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Coverage { get; set; }
        public DateTime Scheduled { get; set; }
        public bool Track_On_Court { get; set; }
        public string Reference { get; set; }
        public string Entry_Mode { get; set; }
        public string Sr_Id { get; set; }
        public Team Home { get; set; }
        public Team Away { get; set; }
        public List<Period> Periods { get; set; }
        public List<DeletedEvent> Deleted_Events { get; set; }




    }
}
