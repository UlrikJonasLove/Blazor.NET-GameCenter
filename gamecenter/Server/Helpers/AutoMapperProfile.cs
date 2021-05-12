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
            CreateMap<Person, Person>();
            CreateMap<Game, Game>();
        }
    }
}
