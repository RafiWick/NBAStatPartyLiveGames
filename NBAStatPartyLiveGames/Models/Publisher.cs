using NBAStatParty.Models.SR_Standings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatPartyLiveGames.Models
{
    public class Publisher
    {
        public List<string> Teams { get; set; } = new List<string>();
        public Dictionary<string, string> Channels = new Dictionary<string, string>();
        public Publisher(SR_Standings standings)
        {
            // get each team and create a channel name
            foreach(var conference in standings.Conferences)
            {
                foreach(var division in conference.Divisions)
                {
                    foreach(var team in division.Teams)
                    {
                        Teams.Add(team.Id);
                        Channels.Add(team.Id, "liveGames:team:" + team.Id);
                    }
                }
            }
        }
    }
}
