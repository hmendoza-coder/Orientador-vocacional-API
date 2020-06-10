using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.Models
{
    public class Carrera
    {
        public int IdCarrera { get; set; }
        public string Nivel { get; set; }
        public int IdUniversidad { get; set; }
        public string Nombre { get; set; }
    }
}
