using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Models.SRPlayByPlay
{
    public class Attribution
    {
        public string Name { get; set; }
        public string Market { get; set; }
        public string Id { get; set; }
        public string Sr_Id { get; set; }
        public string Reference { get; set; }
        public string? Team_Basket { get; set; }
    }
}
