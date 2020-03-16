using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.Models
{
    public class Persona
    {

        public string Nombre { get; set; }

        public string ApellidoP { get; set; }

        public string ApellidoM { get; set; }

        public string Correo { get; set; }

        public int IdCredencial { get; set; }

        public string Sexo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public int idEstado { get; set; }

        public int idMunicipio { get; set; }

        public int idColonia { get; set; }

    }
}
