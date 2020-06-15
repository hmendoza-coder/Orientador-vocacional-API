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
            TestFinalizado ="N";
        }
        public string IdSesion { get; set; }

        public int IdPersona { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string TestFinalizado { get; set; }
    }
}
