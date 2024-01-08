namespace NBAStatParty.Models.SR_Standings
{
    public class Conference
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<Division> Divisions { get; set; }
        public List<Team> Teams { get; set; }


    }
}
