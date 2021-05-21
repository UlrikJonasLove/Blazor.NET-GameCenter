using System.Collections.Generic;
using gamecenter.Shared.Models;

namespace gamecenter.Shared.DTOs
{
    public class GameDetailDTO
    {
        public Game Game { get; set; }
        public List<Genre> Genres { get; set; }       
        public List<Person> PersonInGame { get; set; }        
    }
}