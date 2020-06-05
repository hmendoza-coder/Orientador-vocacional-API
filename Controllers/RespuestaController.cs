using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using OrientadorVocacionalAPI.DTOs.Respuesta;
using OrientadorVocacionalAPI.Models;
using OrientadorVocacionalAPI.Repositories;

namespace OrientadorVocacionalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RespuestaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PreguntaController> _logger;
        private readonly PreguntaRepository _preguntaRepository;
        private readonly SesionRepository _sesionRepository;
        private readonly RespuestaRepository _respuestaRepository;
        private readonly OpcionRepository _opcionRepository;

        public RespuestaController(ILogger<PreguntaController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _preguntaRepository = new PreguntaRepository();
            _sesionRepository = new SesionRepository();
            _respuestaRepository = new RespuestaRepository();
            _opcionRepository = new OpcionRepository();
        }

        [HttpPost]
        public ActionResult Responder(RespuestaDtoIn respuestaDto)
        {
            if (!_preguntaRepository.Exists(respuestaDto.IdPregunta))
                return BadRequest("El numero de pregunta es incorrecto");

            if (!_sesionRepository.Exists(respuestaDto.IdSesion))
                return BadRequest("El id de la persona es incorrecto");

            if (!_opcionRepository.Exists(respuestaDto.IdOpcion))
                return BadRequest("El numero de respuesta es incorrecto");

            Respuesta respuesta = _mapper.Map<Respuesta>(respuestaDto);

            _respuestaRepository.GuardarRespuesta(respuesta);

            return Ok("Respuesta guardada correctamente");
        }
    }
}
