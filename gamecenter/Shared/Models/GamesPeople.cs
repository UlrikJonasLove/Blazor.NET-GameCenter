namespace gamecenter.Shared.Models
{
    public class GamesPeople
    {
        public int PersonId { get; set; }
        public int GameId { get; set; }
        public Person Person { get; set; }
        public Game Game { get; set; } 
        public string RoleOfGame { get; set; }
        public int Order { get; set; }
    }
}