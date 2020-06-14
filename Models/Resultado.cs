using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.Models
{
    public class Resultado
    {
        public int IdResultado { get; set; }

        public string IdSesion { get; set; }

        public int IdCarrera { get; set; }

        public double Afinidad { get; set; }
    }
}
