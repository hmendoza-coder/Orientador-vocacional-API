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
    public class ColoniaController : ControllerBase
    {
        private readonly ColoniaRepository _coloniaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ColoniaController> _logger;

        public ColoniaController(ILogger<ColoniaController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _coloniaRepository = new ColoniaRepository();
        }

        [HttpGet("{idEstado}/{idMunicipio}")]
        public ActionResult GetMunicipios(string idEstado, string idMunicipio)
        {
            var colonia = _coloniaRepository.SelectById(idEstado.ToUpperInvariant(), idMunicipio.ToUpperInvariant());

            if (!colonia.IsNullOrEmpty())
                return Ok(new Response<List<Colonia>>(true, "colonias encontradas", colonia.ToList()));

            return NotFound(new Response(false, "No se encontro el municipio en la base de datos",
                ErrorCode.RegistroNoEncontrado));
        }
    }
}
