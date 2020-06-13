using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.Models
{
    public class CarreraHabilidad
    {
        public CarreraHabilidad(int cantidadHabilidadesTotales, int cantidadHabilidadesConseguidas)
        {
            CantidadHabilidadesTotales = cantidadHabilidadesTotales;
            CantidadHabilidadesConseguidas = cantidadHabilidadesConseguidas;
            Compatibilidad = (cantidadHabilidadesConseguidas * 100)/ cantidadHabilidadesTotales;
        }
        public int IdCarrera { get; set; }

        public string NombreCarrera { get; set; }

        public int CantidadHabilidadesTotales { get; set; }

        public int CantidadHabilidadesConseguidas { get; set; }

        public double Compatibilidad { get; }
    }
}
