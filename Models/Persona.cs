using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.Models
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombres { get; set; }

        public string ApellidoP { get; set; }

        public string ApellidoM { get; set; }

        public string Correo { get; set; }
        
        public string Sexo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }


    }
}
