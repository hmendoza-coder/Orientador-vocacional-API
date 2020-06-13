using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly AreaRepository _areaRepository;
        private readonly CarreraRepository _carreraRepository;

        public ResultadoController(ILogger<PreguntaController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _habilidadRepository = new HabilidadRepository();
            _carreraRepository = new CarreraRepository();
            _areaRepository = new AreaRepository();
        }

        [HttpGet]
        public ActionResult GenerarResultado(string idSesion)
        {
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
                    if (habilidadesConseguidas.Contains(habilidad))
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
            //Guardar el resultado
            return Ok(new Response<List<CarreraHabilidad>>(true, "Resultado generado correctamente", listaCarreraHabilidad));
        }
    }
}
