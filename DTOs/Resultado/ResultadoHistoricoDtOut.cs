using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.DTOs
{
    public class ResultadoHistoricoDtOut
    {
        public DateTime Fecha { get; set; }

        public string Carrera { get; set; }

        public double Afinidad { get; set; }

    }
}
