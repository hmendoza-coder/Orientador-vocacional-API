using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.Models
{
    public class Domicilio
    {
        private int IdDomicilio { get; set; }

        public int IdPersona { get; set; }

        public string IdEstado { get; set; }

        public string IdMunicipio { get; set; }

        public int IdColonia { get; set; }
    }
}
