using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.Models
{
    public class Respuesta
    {
        public int IdRespuesta { get; set; }

        public int idPregunta { get; set; }

        public OpcionRespuesta id_opcion { get; set; }

        public int id_persona { get; set; }

    }
}
