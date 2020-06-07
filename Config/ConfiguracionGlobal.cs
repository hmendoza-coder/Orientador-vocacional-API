using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Config
{
    public class ConfiguracionGlobal
    {
        /// <summary>
        /// Es el numero de preguntas negativas que se aceptaran antes de cambiar de betar el area
        /// </summary>
        public static int INDICE_RECHAZO = 2;

        /// <summary>
        /// Pregunta que se mandara siempre que el cuestionario haya llegado a su fin
        /// </summary>
        public static Pregunta PREGUNTA_FINAL = new Pregunta() {Contenido = "¿Te gustó este cuestionario?", IdArea = 0, IdPregunta = 0};

        /// <summary>
        /// Es el divdendo que se utilizara para determinar la fraccion de preguntas que se deben de responder para cada sesion
        /// </summary>
        public static int INDICE_PARO = 3;
    }
}
