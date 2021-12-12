using AutoMapper;
using OnboardingSoftware.Api.Resources;
using OnboardingSoftware.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Posao, PosaoResource>()
                .ForMember(x => x.Lokacija, opt => opt.MapFrom(y => y.Lokacija.Naziv));
        }
    }
}
