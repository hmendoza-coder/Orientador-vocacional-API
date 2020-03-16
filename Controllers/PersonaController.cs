using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly ILogger<PersonaController> _logger;
        public PersonaController(ILogger<PersonaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            var persona = new Persona();
            persona.Sexo = "hombre";
            persona.Correo = "elchido@gmail.com";
            persona.FechaNacimiento = new DateTime(1995,3,15);
            persona.ApellidoM = "Hernandez";
            persona.ApellidoP = "Mendoza";
            persona.IdCredencial = 1;
            persona.Nombre = "Juean";
            persona.idColonia = 1;
            persona.idEstado = 2;
            persona.idMunicipio = 3;
            var ListPersonas = new List<Persona>();
            ListPersonas.Add(persona);
            return ListPersonas;

            return Enumerable.Range(1, 2).Select(index => new Persona
                {
                Sexo = "hombre",
                Correo = "elchido@gmail.com",
                FechaNacimiento = new DateTime(1900, 03, 15),
                ApellidoM = "Hernandez",
                ApellidoP = "Mendoza",
                IdCredencial = 1,
                Nombre = "Juean",
                idColonia = 1,
                idEstado = 2,
                idMunicipio = 3

            })
                .ToArray();
        }
    }
}
