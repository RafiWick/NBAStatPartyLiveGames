namespace NBAStatParty.Models.SR_Standings
{
    public class Division
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<Team> Teams { get; set; }

    }
}
