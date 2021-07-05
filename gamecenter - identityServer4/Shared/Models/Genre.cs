using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gamecenter.Shared.Models
{
    public class Genre 
    {
        public int Id { get; set; }
        [Required(ErrorMessage="This field is Required.")]
        public string Name { get; set; }  
        public List<GamesGenres> GamesGenres { get ; set; } = new List<GamesGenres>();
    }  
}