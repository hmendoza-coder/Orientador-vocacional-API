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
        private readonly AreaRepository _areaRepository;
        private readonly CarreraRepository _carreraRepository;

        public ResultadoController(ILogger<PreguntaController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _habilidadRepository = new HabilidadRepository();
            _carreraRepository = new CarreraRepository();
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
                if (habilidad.Cantidad > p.Cantidad / ConfiguracionGlobal.FRACCION_NECESARIA_PARA_HABILIDAD)
                    habilidadesConseguidas.Add(habilidad);
            }

            var idAreaFavorita = _areaRepository.ObtenerAreaFavorita(idSesion);
            var listaCarreras = _carreraRepository.ObtenerCarreras(idAreaFavorita);

            foreach (Carrera carrera in listaCarreras)
            {
                //Obtener las habilidades de la carrera
                //por cada habilidad comparar
            }
            return Ok("Resultado obtenido correctamente");
        }
    }
}
