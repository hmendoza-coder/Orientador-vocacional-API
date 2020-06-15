using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrientadorVocacionalAPI.Config;
using OrientadorVocacionalAPI.DTOs;
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
        private readonly AreaRepository _areaRepository;
        private readonly CarreraRepository _carreraRepository;
        private readonly ResultadoRepository _resultadoRepository;
        private readonly SesionRepository _sesionRepository;

        public ResultadoController(ILogger<PreguntaController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _habilidadRepository = new HabilidadRepository();
            _carreraRepository = new CarreraRepository();
            _areaRepository = new AreaRepository();
            _resultadoRepository = new ResultadoRepository();
            _sesionRepository = new SesionRepository();
        }

        [HttpGet]
        public ActionResult GenerarResultado(string idSesion)
        {
            if(!_sesionRepository.TestFinalizado(idSesion))
                return BadRequest("La sesion no tiene finalizada el test");

            var habilidadesRespondidas = _habilidadRepository.ContarHabilidadesRespondidas(idSesion);
            var habilidadesPotenciales = _habilidadRepository.ContarHabilidadesPotenciales(idSesion);
            var habilidadesConseguidas = new List<Habilidad>();

            foreach (Habilidad habilidad in habilidadesPotenciales)
            {
                var habilidadRespondida = habilidadesRespondidas.FirstOrDefault(x => x.IdHabilidad.Equals(habilidad.IdHabilidad));
                if (habilidadRespondida.IsNull())
                    continue;
                if (habilidad.Cantidad > habilidadRespondida.Cantidad / ConfiguracionGlobal.FRACCION_NECESARIA_PARA_HABILIDAD)
                    habilidadesConseguidas.Add(habilidad);
            }

            var idAreaFavorita = _areaRepository.ObtenerAreaFavorita(idSesion);
            var listaCarreras = _carreraRepository.ObtenerCarreras(idAreaFavorita);
            var listaCarreraHabilidad = new List<CarreraHabilidad>();

            foreach (Carrera carrera in listaCarreras)
            {
                var listaHabilidadesCarrera = _habilidadRepository.ObtenerHabilidadesCarrera(carrera.IdCarrera);
                int numHabilidadesCarrera=0;

                foreach (Habilidad habilidad in listaHabilidadesCarrera)
                {
                    if (habilidadesConseguidas.Any(e => e.IdHabilidad.Equals(habilidad.IdHabilidad)))
                        numHabilidadesCarrera++;
                }
                if (numHabilidadesCarrera.Equals(0))
                    continue;
                var carreraHabilidad = new CarreraHabilidad(listaHabilidadesCarrera.Count, numHabilidadesCarrera)
                {
                    IdCarrera = carrera.IdCarrera, NombreCarrera = carrera.Nombre
                };
                listaCarreraHabilidad.Add(carreraHabilidad);
            }

            List<ResultadoDtoOut> resultados = new List<ResultadoDtoOut>();
            foreach (var elemento in listaCarreraHabilidad.OrderByDescending(e => e.Afinidad).Take(ConfiguracionGlobal.CANTIDAD_CARRERAS_GUARDADAS))
            {
                Resultado resultado = new Resultado
                {
                    IdSesion = idSesion, Afinidad = elemento.Afinidad, IdCarrera = elemento.IdCarrera
                };
                _resultadoRepository.Insert(resultado);
                resultados.Add(_mapper.Map<ResultadoDtoOut>(elemento));
            }

            return Ok(new Response<List<ResultadoDtoOut>>(true, "Resultado generado correctamente", resultados));
        }
    }
}
