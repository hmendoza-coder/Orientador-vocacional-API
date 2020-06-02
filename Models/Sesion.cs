using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.Models
{
    public class Sesion
    {
        public Sesion()
        {
            IdSesion = Guid.NewGuid().ToString();
            FechaInicio = DateTime.Now;
        }
        public string IdSesion { get; set; }

        public string idPersona { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
    }
}
