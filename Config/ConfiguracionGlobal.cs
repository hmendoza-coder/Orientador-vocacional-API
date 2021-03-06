﻿using System;
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
        public static int INDICE_RECHAZO = 3;

        /// <summary>
        /// Pregunta que se mandara siempre que el cuestionario haya llegado a su fin
        /// </summary>
        public static Pregunta PREGUNTA_FINAL = new Pregunta() {Contenido = "¿Te gustó este cuestionario?", IdArea = 0, IdPregunta = 0};

        /// <summary>
        /// Es el divisor que se utilizara para determinar la fraccion de preguntas que se deben de responder para cada sesion
        /// </summary>
        public static int INDICE_PARO = 3;

        /// <summary>
        /// Divisor que define que fraccion de las habilidades respondidas se necesita obtener para conseguir la habilidad
        /// </summary>
        public static int FRACCION_NECESARIA_PARA_HABILIDAD = 2;

        /// <summary>
        /// Define el numero de registros por test que seran guardados en la tabla de resultados
        /// </summary>
        public static int CANTIDAD_CARRERAS_GUARDADAS = 3;
    }
}
