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

        public PreguntaController(ILogger<PreguntaController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _preguntaRepository = new PreguntaRepository();
        }

        [HttpGet]
        public ActionResult ObtenerPrimerPregunta()
        {
            return Ok(new Response<Pregunta>(true, "Primer pregunta obtenida correctamente", _preguntaRepository.ObtenerPrimerPregunta()));
        }
    }
}
