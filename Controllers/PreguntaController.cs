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
    public class PreguntaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PreguntaController> _logger;
        private readonly PreguntaRepository _preguntaRepository;
        private readonly SesionRepository _sesionRepository;
        private readonly RespuestaRepository _respuestaRepository;
        private readonly AreaRepository _areaRepository;

        public PreguntaController(ILogger<PreguntaController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _preguntaRepository = new PreguntaRepository();
            _sesionRepository = new SesionRepository();
            _respuestaRepository = new RespuestaRepository();
            _areaRepository = new AreaRepository();
        }

        private bool CuestionarioFinalizado(string idSesion)
        {
            int cantidadPreguntas = _preguntaRepository.ContarTotalPreguntas() / ConfiguracionGlobal.INDICE_PARO;
            return _respuestaRepository.ContarRespuestas(idSesion).Equals(cantidadPreguntas);
        }

        [HttpGet]
        public ActionResult ObtenerPregunta(string idSesion)
        {
            if (!_sesionRepository.SesionValida(idSesion))
                return BadRequest("El id de sesión proporcionado no es valido");

            var sesion = _sesionRepository.ObtenerSesion(idSesion);

            if(CuestionarioFinalizado(idSesion))
            {
                _sesionRepository.MarcarTestFinalizado(idSesion);
                return Ok(new Response<Pregunta>(true, "Pregunta obtenida correctamente",
                    ConfiguracionGlobal.PREGUNTA_FINAL));
            }

            if (!_respuestaRepository.TieneRespuestas(sesion.IdSesion))
                return Ok(new Response<Pregunta>(true, "Pregunta obtenida correctamente", _preguntaRepository.ObtenerPrimerPregunta()));

            var ultimaRespuesta = _respuestaRepository.ObtenerUltimaRespuesta(idSesion);

            var ultimaArea = _areaRepository.ObtenerArea(ultimaRespuesta.IdPregunta);
            
            List<int> listaAreasDescartadas = _areaRepository.ObtenerAreasDescartadas(idSesion).Select(descartada => descartada.IdArea).ToList();

            if (ultimaRespuesta.IdOpcion.Equals((short)OpcionRespuesta.Nada))
                listaAreasDescartadas.Add(ultimaArea.IdArea);

            Pregunta pregunta;
            do
            {
                var areasDisponibles = _areaRepository.ObtenerAreasExcepto(listaAreasDescartadas);

                if (areasDisponibles.Count().Equals(0))
                {
                    _sesionRepository.MarcarTestFinalizado(idSesion);
                    return Ok(new Response<Pregunta>(true, "Pregunta obtenida correctamente",
                        ConfiguracionGlobal.PREGUNTA_FINAL));
                }
                
                var areaRandom = areasDisponibles.ElementAtOrDefault(new Random().Next(0, areasDisponibles.Count()))
                    .IdArea;

                pregunta = _preguntaRepository.ObtenerSiguientePregunta(areaRandom, idSesion);
                listaAreasDescartadas.Add(areaRandom);

            } while (pregunta.IsNull() || pregunta.IdPregunta.Equals(0));


            return Ok(new Response<Pregunta>(true, "Pregunta obtenida correctamente",pregunta));
        }
    }
}
