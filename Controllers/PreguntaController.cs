using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrientadorVocacionalAPI.Models;
using OrientadorVocacionalAPI.Repositories;

namespace OrientadorVocacionalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreguntaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PreguntaController> _logger;
        private readonly PreguntaRepository _preguntaRepository;
        private readonly SesionRepository _sesionRepository;
        private readonly RespuestaRepository _respuestaRepository;

        public PreguntaController(ILogger<PreguntaController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _preguntaRepository = new PreguntaRepository();
            _sesionRepository = new SesionRepository();
            _respuestaRepository = new RespuestaRepository();
        }

        [HttpGet]
        public ActionResult ObtenerPregunta(string idSesion)
        {
            if (!_sesionRepository.SesionValida(idSesion))
                return BadRequest("El id de sesión proporcionado no es valido");

            return Ok(new Response<Pregunta>(true, "Pregunta obtenida correctamente", _preguntaRepository.ObtenerPregunta(idSesion)));
        }
    }
}
