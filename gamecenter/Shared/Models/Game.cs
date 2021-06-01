using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gamecenter.Shared.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        public bool NewlyReleases { get; set; }
        public string Trailer { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        public string Poster { get; set; }
        public List<GamesGenres> GamesGenres { get ; set; } = new List<GamesGenres>();
        public List<GamesPeople> GamesPeople { get; set; } = new List<GamesPeople>();
        public string TitleBrief 
        {
            get 
            {
                if(string.IsNullOrEmpty(Title))
                {
                    return null;
                }

                if(Title.Length > 60)
                {
                    return Title.Substring(0, 60) + "...";
                }

                else 
                {
                    return Title;
                }
            }
        }
    }   
}