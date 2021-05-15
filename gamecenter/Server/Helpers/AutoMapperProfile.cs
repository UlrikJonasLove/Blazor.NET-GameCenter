using AutoMapper;
using gamecenter.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamecenter.Server.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, Person>()
                .ForMember(x => x.Picture, option => option.Ignore()); 
            CreateMap<Game, Game>()
                .ForMember(x => x.Poster, option => option.Ignore());
        }
    }
}
