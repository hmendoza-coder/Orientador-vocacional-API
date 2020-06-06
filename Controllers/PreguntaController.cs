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

        [HttpGet]
        public ActionResult ObtenerPregunta(string idSesion)
        {
            if (!_sesionRepository.SesionValida(idSesion))
                return BadRequest("El id de sesión proporcionado no es valido");

            var sesion = _sesionRepository.ObtenerSesion(idSesion);
            var pregunta = new Pregunta();

            if (!_respuestaRepository.TieneRespuestas(sesion.IdSesion))
                pregunta = _preguntaRepository.ObtenerPrimerPregunta();

            var ultimaRespuesta = _respuestaRepository.ObtenerUltimaRespuesta(idSesion);

            var area = _areaRepository.ObtenerArea(ultimaRespuesta.IdPregunta);

            var areasDescartadas = _areaRepository.ObtenerAreasDescartadas(idSesion);

            List<int> listaAreas = new List<int>();

            foreach (Area descartada in areasDescartadas)
            {
                listaAreas.Add(descartada.IdArea);
            }

            var areasDisponibles = _areaRepository.ObtenerAreasExcepto(listaAreas);

            if (areasDisponibles.Count().Equals(0))
            {
                //Se acabaron las areas
            }

            var randgen = new Random();
            var areaRandom = areasDisponibles.ElementAtOrDefault(randgen.Next(0,areasDisponibles.Count()));

            //Validar que no se hayan acabado las areas

            if (ultimaRespuesta.IdRespuesta.Equals(OpcionRespuesta.Nada))
            {
                //CAMBIAR AREA, EXCLUYENDO EL AREA ACTUAL
            }
            else
            {
                //QUEDARSE EN EL AREA ACTUAL
            }
            
            return Ok(new Response<Pregunta>(true, "Pregunta obtenida correctamente",pregunta));
        }
    }
}
