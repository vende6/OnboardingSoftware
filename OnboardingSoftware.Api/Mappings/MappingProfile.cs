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

            CreateMap<SavePosaoResource, Posao>();
            CreateMap<SavePosaoResource, Lokacija>();

            CreateMap<Test, TestResource>();
            CreateMap<TestResource, Test>()
             .ForMember(x => x.OsvojeniProcenat, opt => opt.MapFrom(y => "N/A"))
             .ForMember(x => x.Pocetak, opt => opt.MapFrom(y => DateTime.Now))
             .ForMember(x => x.Kraj, opt => opt.MapFrom(y => DateTime.Now.AddMinutes(2)));

            CreateMap<LokacijaResource, Lokacija>()
             .ForMember(x => x.Naziv, opt => opt.MapFrom(y => y.Naziv))
             .ForMember(x => x.Adresa, opt => opt.MapFrom(y => "N/A"))
             .ForMember(x => x.Opis, opt => opt.MapFrom(y => "N/A"))
             .ForMember(x => x.Sektor, opt => opt.MapFrom(y => "N/A"));

            CreateMap<Pitanje, PitanjeResource>()
                .ForMember(x => x.Test, opt => opt.MapFrom(y => y.Test.Naziv));
            CreateMap<SavePitanjeResource, Pitanje>();
        }
    }
}
