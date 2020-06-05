using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.DTOs.Respuesta
{
    public class RespuestaDtoIn
    {
        public int IdPregunta { get; set; }

        public string IdSesion { get; set; }

        public int IdOpcion { get; set; }

    }
}
