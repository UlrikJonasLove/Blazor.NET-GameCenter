using System.Collections.Generic;
using gamecenter.Shared.Models;

namespace gamecenter.Shared.DTOs
{
    public class UpdateGameDTO
    {
        public Game Game { get; set; }
        public List<Person> People { get; set; }
        public List<Genre> SelectedGenres { get; set; }
        public List<Genre> NotSelectedGenres { get; set; }      
    }
}