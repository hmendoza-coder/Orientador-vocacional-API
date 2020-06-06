using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrientadorVocacionalAPI.DTOs;
using OrientadorVocacionalAPI.Models;
using OrientadorVocacionalAPI.Repositories;

namespace OrientadorVocacionalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly ILogger<PersonaController> _logger;
        private readonly PersonaRepository _personaRepository;
        private readonly CredencialRepository _credencialRepository;
        private readonly DomicilioRepository _domicilioRepository;
        private readonly IMapper _mapper;

        public PersonaController(ILogger<PersonaController> logger, IMapper mapper)
        {
            _logger = logger;
            _personaRepository = new PersonaRepository();
            _credencialRepository = new CredencialRepository();
            _domicilioRepository = new DomicilioRepository();
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetPersonas()
        {
            return Ok(new Response<List<Persona>>(true, "personas obtenidas correctamente", _personaRepository.SelectAll()));
        }

        //[HttpPost]
        //public ActionResult Post(Persona persona)
        //{
        //    try
        //    {
        //        _personaRepository.InsertPersona(persona);
        //        return Ok(new Response(true, "Persona agregada correctamente"));
        //    }
        //    catch (Exception )
        //    {
        //        return BadRequest("Error al ingresar la persona a la base de datos");
        //    }

        //}

        [HttpPost]
        public ActionResult AgregarPersona(PersonaDtoIn personaDtoIn)
        {

            Persona persona = _mapper.Map<Persona>(personaDtoIn);

            if(_personaRepository.Exists(persona.Correo))
                return BadRequest("El correo proporcionado ya existe en la base");

            try
            {
                _personaRepository.InsertPersona(persona);

                persona.IdPersona = _personaRepository.ObtenerIdPersonaByCorreo(persona.Correo);

                if(persona.IdPersona.IsNull() || persona.IdPersona.Equals(0))
                    return BadRequest("Error al ingresar la persona a la base de datos");

                Credencial credencial = new Credencial
                {
                    Password = personaDtoIn.Password, IdPersona = persona.IdPersona
                };

                _credencialRepository.Insert(credencial);

                Domicilio domicilio = new Domicilio
                {
                    IdMunicipio = personaDtoIn.IdMunicipio,
                    IdColonia = personaDtoIn.IdColonia,
                    IdEstado = personaDtoIn.IdEstado,
                    IdPersona = persona.IdPersona
                };

                _domicilioRepository.Insert(domicilio);

                return Ok(new Response(true, "Persona agregada correctamente"));
            }
            catch (Exception)
            {
                _personaRepository.DeleteByCorreo(persona.Correo);
                return BadRequest("Error al ingresar la persona a la base de datos");
            }

        }

        //[HttpGet]
        //[Route("async")]
        //public async Task<IEnumerable<Persona>> ObtenerPersonasAsync()
        //{
        //    Connection myConnection;
        //    myConnection = new Connection();
        //    return await myConnection.CreateDataTableAsync("SELECT * FROM persona").ToList<Persona>();
        //}

    }
}
