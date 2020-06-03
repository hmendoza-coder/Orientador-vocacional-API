using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrientadorVocacionalAPI.DTOs;
using OrientadorVocacionalAPI.Models;
using OrientadorVocacionalAPI.Repositories;

namespace OrientadorVocacionalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SesionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<SesionController> _logger;
        private readonly SesionRepository _sesionRepository;
        private readonly CredencialRepository _credencialRepository;

        public SesionController(ILogger<SesionController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _sesionRepository = new SesionRepository();
            _credencialRepository = new CredencialRepository();
        }

        [HttpGet]
        public ActionResult Login([FromQuery] CredencialDtoIn credencial)
        {

           var estatus = _credencialRepository.VerificarCredencial(credencial);
           SesionDtOut sesionDtOut = new SesionDtOut();

            if (estatus.Equals(Credencial.Estatus.Ok))
            {
                Sesion sesion = new Sesion {idPersona = credencial.IdPersona};
                sesionDtOut.Estatus = Credencial.Estatus.Ok;
                sesionDtOut.IdSesion = sesion.IdSesion;
                _sesionRepository.Insert(sesion);
                return Ok(new Response<SesionDtOut>(true, "Usuario logeado correctamente", sesionDtOut));
            }

            sesionDtOut.Estatus = estatus;
            sesionDtOut.IdSesion = String.Empty;
            return BadRequest("Error al logear al usuario: " + sesionDtOut.Estatus);
        }
    }
}
