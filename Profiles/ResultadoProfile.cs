using AutoMapper;
using OrientadorVocacionalAPI.DTOs;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Profiles
{
    public class ResultadoProfile : Profile
    {
        public ResultadoProfile()
        {
            CreateMap<CarreraHabilidad, ResultadoDtoOut > ()
                .ForMember(src => src.Afinidad, opt => opt.MapFrom(des => des.Afinidad))
                .ForMember(src => src.Carrera, opt => opt.MapFrom(des => des.NombreCarrera))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
