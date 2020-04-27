using AutoMapper;
using OrientadorVocacionalAPI.DTOs;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Profiles
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            CreateMap<PersonaDtoIn, Persona>()
                .ForMember(src => src.ApellidoM, opt => opt.MapFrom(des => des.ApellidoM))
                .ForMember(src => src.ApellidoP, opt => opt.MapFrom(des => des.ApellidoP))
                .ForMember(src => src.Nombres, opt => opt.MapFrom(des => des.Nombres))
                .ForMember(src => src.FechaNacimiento, opt => opt.MapFrom(des => des.FechaNacimiento))
                .ForMember(src => src.Correo, opt => opt.MapFrom(des => des.Correo))
                .ForMember(src => src.Sexo, opt => opt.MapFrom(des => des.Sexo))
                .ForAllOtherMembers(opt => opt.Ignore());

        }
        
    }
}
