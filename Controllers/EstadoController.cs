using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly ILogger<PersonaController> _logger;
        private readonly EstadoRepository _estadoRepository;
        //private readonly IMapper _mapper;

        public EstadoController(ILogger<PersonaController> logger/*, IMapper mapper*/)
        {
            _logger = logger;
            _estadoRepository = new EstadoRepository();
            //_mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetEstados()
        {
            return Ok(new Response<List<Estado>>(true, "estados obtenidas correctamente", _estadoRepository.SelectAll()));
        }

        [HttpGet("{idEstado}")]
        public ActionResult GetEstados(string idEstado)
        {
            var estado = _estadoRepository.SelectById(idEstado.ToUpperInvariant());
            if (!estado.IsNullOrEmpty())
                return Ok(new Response<Estado>(true, "estado encontrado", estado));

            return NotFound(new Response(false, "No se encontro el estado en la base de datos",
                ErrorCode.RegistroNoEncontrado));
        }
    }
}