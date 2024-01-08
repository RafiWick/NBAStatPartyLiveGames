namespace NBAStatParty.Models.SR_Standings
{
    public class SR_Standings
    {
        public League League { get; set; }
        public Season Season { get; set; }
        public List<Conference> Conferences { get; set; }
    }
}
