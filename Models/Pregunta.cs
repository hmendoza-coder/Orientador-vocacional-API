using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.Models
{
    public class Pregunta
    {
        public int IdPregunta { get; set; }

        public int IdArea { get; set; }

        public string Contenido { get; set; }

    }
}
