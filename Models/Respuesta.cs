﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.Models
{
    public class Respuesta
    {
        public int IdRespuesta { get; set; }

        public string IdSesion { get; set; }

        public int IdPregunta { get; set; }

        public int IdOpcion { get; set; }

    }
}
