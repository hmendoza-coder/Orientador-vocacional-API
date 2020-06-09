using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrientadorVocacionalAPI.Config;
using OrientadorVocacionalAPI.Models;
using OrientadorVocacionalAPI.Repositories;

namespace OrientadorVocacionalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultadoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PreguntaController> _logger;
        private readonly HabilidadRepository _habilidadRepository;
        private readonly SesionRepository _sesionRepository;
        private readonly RespuestaRepository _respuestaRepository;
        private readonly AreaRepository _areaRepository;

        public ResultadoController(ILogger<PreguntaController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _habilidadRepository = new HabilidadRepository();
        }

        [HttpGet]
        public ActionResult GenerarResultado(string idSesion)
        {
            var habilidades = _habilidadRepository.ContarHabilidadesRespondidas(idSesion);
            var habilidadesPotenciales = _habilidadRepository.ContarHabilidadesPotenciales(idSesion);
            var habilidadesConseguidas = new List<Habilidad>();

            foreach (Habilidad habilidad in habilidadesPotenciales)
            {
                var p = habilidades.FirstOrDefault(x => x.IdHabilidad.Equals(habilidad.IdHabilidad));
                if (p.IsNull())
                    continue;
                if (habilidad.Cantidad > p.Cantidad/ConfiguracionGlobal.FRACCION_NECESARIA_PARA_HABILIDAD)
                    habilidadesConseguidas.Add(habilidad);
            }

            return Ok("Resultado obtenido correctamente");
        }
    }
}
