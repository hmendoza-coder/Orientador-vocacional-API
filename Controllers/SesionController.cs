﻿using System;
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
        private readonly PersonaRepository _personaRepository;

        public SesionController(ILogger<SesionController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _sesionRepository = new SesionRepository();
            _credencialRepository = new CredencialRepository();
            _personaRepository = new PersonaRepository();
        }

        [HttpGet("login")]
        public ActionResult Login([FromQuery] CredencialDtoIn credencial)
        {

           var estatus = _credencialRepository.VerificarCredencial(credencial);
           SesionDtOut sesionDtOut = new SesionDtOut();

            if (estatus.Equals(Credencial.Estatus.Ok))
            {
                var sesion = new Sesion {IdPersona = _personaRepository.ObtenerIdPersonaByCorreo(credencial.Correo)};
                sesionDtOut.Estatus = Credencial.Estatus.Ok;
                sesionDtOut.IdSesion = sesion.IdSesion;
                _sesionRepository.Insert(sesion);
                return Ok(new Response<SesionDtOut>(true, "Usuario logeado correctamente", sesionDtOut));
            }

            sesionDtOut.Estatus = estatus;
            sesionDtOut.IdSesion = String.Empty;
            return BadRequest("Error al logear al usuario: " + sesionDtOut.Estatus);
        }

        [HttpPatch("logout")]
        public ActionResult Logout(string idSesion)
        {
            if (!_sesionRepository.Exists(idSesion))
                return BadRequest("La sesion indicada no existe");

            if (_sesionRepository.TieneFechaFin(idSesion))
                return BadRequest("La sesion ya había sido cerrada anteriormente");

                _sesionRepository.ActualizarFechaFin(idSesion);
            return Ok("Sesion cerrada correctamente");
        }
    }
}
