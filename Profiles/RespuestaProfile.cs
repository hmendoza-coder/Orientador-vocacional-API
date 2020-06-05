using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OrientadorVocacionalAPI.DTOs;
using OrientadorVocacionalAPI.DTOs.Respuesta;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Profiles
{
    public class RespuestaProfile : Profile
    {
        public RespuestaProfile()
        {
            CreateMap<RespuestaDtoIn, Respuesta>()
                .ForMember(src => src.IdPregunta, opt => opt.MapFrom(des => des.IdPregunta))
                .ForMember(src => src.IdOpcion, opt => opt.MapFrom(des => des.IdOpcion))
                .ForMember(src => src.IdSesion, opt => opt.MapFrom(des => des.IdSesion))
                .ForAllOtherMembers(opt => opt.Ignore());

        }
    }
}
