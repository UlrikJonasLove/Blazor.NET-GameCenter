using System.Collections.Generic;
using gamecenter.Shared.Models;

namespace gamecenter.Shared.DTOs
{
    public class IndexPageDTO
    {
        public List<Game> NewlyReleases { get; set; }
        public List<Game> UpcomingReleases { get; set; }
    }
    
}