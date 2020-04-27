using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MunicipioController : ControllerBase
    {
        private readonly MunicipioRepository _municipioRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonaController> _logger;

        public MunicipioController(ILogger<PersonaController> logger, IMapper mapper)
        {
            _logger = logger;
            _municipioRepository = new MunicipioRepository();
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetMunicipios()
        {
            return Ok(new Response<List<Municipio>>(true, "Municipios obtenidas correctamente", _municipioRepository.SelectAll()));
        }

        //[HttpGet("{idEstado}")]
        //public ActionResult GetEstados(string idEstado)
        //{
        //    var estado = _estadoRepository.SelectById(idEstado.ToUpperInvariant());
        //    if (!estado.IsNullOrEmpty())
        //        return Ok(new Response<Estado>(true, "estado encontrado", estado));

        //    return NotFound(new Response(false, "No se encontro el estado en la base de datos",
        //        ErrorCode.RegistroNoEncontrado));
        //}
    }
}
