﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.Models
{
    public class Colonia
    {
        public int IdColonia { get; set; }

        public string IdEstado { get; set; }

        public string IdMunicipio { get; set; }

        public string Nombre { get; set; }
    }
}
