namespace gamecenter.Shared.Models
{
    public class GamesGenres
    {
        public int GameId { get; set; }
        public int GenresId { get; set; }  
        public Game Game { get; set; }
        public Genre Genre { get; set; }            
    }
}