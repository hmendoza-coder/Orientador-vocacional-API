using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        public IEnumerable<Persona> ObtenerPersonas()
        {
            Connection myConnection;
            myConnection = new Connection();
            return myConnection.CreateDataTable("SELECT * FROM persona").ToList<Persona>();
        }

    }
}
