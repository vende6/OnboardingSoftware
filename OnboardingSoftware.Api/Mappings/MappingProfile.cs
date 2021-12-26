using AutoMapper;
using OnboardingSoftware.Api.Resources;
using OnboardingSoftware.Core.Models;
using OnboardingSoftware.Core.Models.Auth.MyMusic.Core.Models.Auth;
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
            CreateMap<UserSignupResource, Aplikant>()
               .ForMember(x => x.Email, opt => opt.MapFrom(y => y.Email))
               .ForMember(x => x.Ime, opt => opt.MapFrom(y => y.FirstName))
               .ForMember(x => x.Prezime, opt => opt.MapFrom(y => y.LastName))
               .ForMember(x => x.Lozinka, opt => opt.MapFrom(y => y.Password))
               .ForMember(x => x.BrojTelefona, opt => opt.MapFrom(y => ""))
               .ForMember(x => x.MjestoRodjenja, opt => opt.MapFrom(y => ""))
               .ForMember(x => x.DatumRodjenja, opt => opt.MapFrom(y => ""))
               .ForMember(x => x.Adresa, opt => opt.MapFrom(y => ""))
               .ForMember(x => x.StatusZaposlenja, opt => opt.MapFrom(y => ""))
               .ForMember(x => x.LokacijaZaposlenja, opt => opt.MapFrom(y => ""))
               .ForMember(x => x.TrenutnaPozicija, opt => opt.MapFrom(y => ""));

            CreateMap<Posao, PosaoResource>()
                .ForMember(x => x.Lokacija, opt => opt.MapFrom(y => y.Lokacija.Naziv));
            CreateMap<SavePosaoResource, Posao>();
            CreateMap<SavePosaoResource, Lokacija>()
                 .ForMember(x => x.Naziv, opt => opt.MapFrom(y => y.Lokacija.Naziv));

            CreateMap<Test, TestResource>();
            CreateMap<TestResource, Test>()
             .ForMember(x => x.OsvojeniProcenat, opt => opt.MapFrom(y => "N/A"))
             .ForMember(x => x.Pocetak, opt => opt.MapFrom(y => DateTime.Now))
             .ForMember(x => x.Kraj, opt => opt.MapFrom(y => DateTime.Now.AddMinutes(2)));
            CreateMap<Test, SaveTestResource>();
            CreateMap<SaveTestResource, Test>()
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

            CreateMap<Odgovor, OdgovorResource>()
                 .ForMember(x => x.TipPitanja, opt => opt.MapFrom(y => y.Pitanje.Tip));
            CreateMap<SaveOdgovorResource, Odgovor>();
            CreateMap<UpdateOdgovoriResource, Odgovor>();
            CreateMap<OdgovorResource, Odgovor>();

            CreateMap<UserSignupResource, User>()
               .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));

            CreateMap<Aplikant, AplikantResource>();

            CreateMap<IEnumerable<AplikantTest>, AplikantiTestResource>()
                            .ForMember(u => u.Aplikanti, opt => opt.MapFrom(ur => ur));
            CreateMap<AplikantTest, AplikantResource>()
               .ForMember(x => x.Email, opt => opt.MapFrom(y => y.Aplikant.Email))
               .ForMember(x => x.Ime, opt => opt.MapFrom(y => y.Aplikant.Ime))
               .ForMember(x => x.Prezime, opt => opt.MapFrom(y => y.Aplikant.Prezime))
               .ForMember(x => x.BrojTelefona, opt => opt.MapFrom(y => ""))
               //.ForMember(x => x.MjestoRodjenja, opt => opt.MapFrom(y => ""))
               //.ForMember(x => x.DatumRodjenja, opt => opt.MapFrom(y => ""))
               .ForMember(x => x.Adresa, opt => opt.MapFrom(y => ""));


            CreateMap<IEnumerable<AplikantPosao>, AplikantiPosaoResource>()
                            .ForMember(u => u.Aplikanti, opt => opt.MapFrom(ur => ur));
            CreateMap<AplikantPosao, AplikantResource>()
               .ForMember(x => x.Email, opt => opt.MapFrom(y => y.Aplikant.Email))
               .ForMember(x => x.Ime, opt => opt.MapFrom(y => y.Aplikant.Ime))
               .ForMember(x => x.Prezime, opt => opt.MapFrom(y => y.Aplikant.Prezime))
               .ForMember(x => x.BrojTelefona, opt => opt.MapFrom(y => ""))
               //.ForMember(x => x.MjestoRodjenja, opt => opt.MapFrom(y => ""))
               //.ForMember(x => x.DatumRodjenja, opt => opt.MapFrom(y => ""))
               .ForMember(x => x.Adresa, opt => opt.MapFrom(y => ""));

            CreateMap<Vjestina, VjestinaResource>();
            CreateMap<Vjestina, SkillResource>();

            CreateMap<IEnumerable<InteresResource>, AplikantInteresiResource>()
                            .ForMember(u => u.Interesi, opt => opt.MapFrom(ur => ur));
            CreateMap<Interes, InteresResource>()
               .ForMember(u => u.ID, opt => opt.MapFrom(ur => ur.ID))
               .ForMember(u => u.Naziv, opt => opt.MapFrom(ur => ur.Naziv));

            CreateMap<IEnumerable<VjestinaResource>, AplikantVjestineResource>()
                            .ForMember(u => u.Vjestine, opt => opt.MapFrom(ur => ur));
            CreateMap<AplikantVjestina, VjestinaResource>()
               .ForMember(u => u.ID, opt => opt.MapFrom(ur => ur.VjestinaID))
               .ForMember(u => u.Naziv, opt => opt.MapFrom(ur => ur.Vjestina.Naziv));

            CreateMap<SaveInteresResource, Interes>();
            CreateMap<SaveVjestinaResource, Vjestina>();

            CreateMap<SaveAplikantTestResource, AplikantTest>();
            CreateMap<SaveAplikantPosaoResource, AplikantPosao>();


            CreateMap<SaveAplikantInteresiResource, IEnumerable<AplikantInteres>>();
            CreateMap<SaveInteresResource, AplikantInteres>()
            .ForMember(u => u.AplikantID, opt => opt.MapFrom(ur => ur.AplikantID))
            .ForMember(u => u.InteresID, opt => opt.MapFrom(ur => ur.InteresID));

            CreateMap<SaveAplikantVjestineResource, IEnumerable<AplikantVjestina>>();
            CreateMap<AplikantVjestinaResource, AplikantVjestina>()
            .ForMember(u => u.AplikantID, opt => opt.MapFrom(ur => ur.AplikantID))
            .ForMember(u => u.VjestinaID, opt => opt.MapFrom(ur => ur.VjestinaID));

            CreateMap<UpdateAplikantResource, Aplikant>();


            CreateMap<Interes, InterestResource>()
               .ForMember(u => u.ID, opt => opt.MapFrom(ur => ur.ID))
               .ForMember(u => u.Naziv, opt => opt.MapFrom(ur => ur.Naziv));
            CreateMap<SaveInterestResource, Interes>();
        }
    }
}
