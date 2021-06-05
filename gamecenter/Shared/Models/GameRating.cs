using System;

namespace gamecenter.Shared.Models
{
    public class GameRating
    {
        public int Id { get; set; }       
        public int Rate { get; set; }        
        public DateTime RatingDate { get; set; }        
        public int GameId { get; set; }
        public Game Game { get; set; }        
        public string UserId { get; set; }
    }
}