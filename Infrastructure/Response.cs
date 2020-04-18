using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI
{
    /// <summary>
    /// Response estandar para cualquier peticion a la API de SIAC
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> where T : class, new()
    {
        #region Propiedades
        /// <summary>
        /// indita si el proceso fue satisfactorio o no
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Mensaje de Response
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Resultado de la petición
        /// </summary>
        public T Datos { get; set; }

        public ErrorCode CodigoError { get; set; }

        public string CheckSum { get; set; }

        #endregion Propiedades

        /// <summary>
        /// Constructor
        /// </summary>
        public Response()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="status"></param>
        /// <param name="mensaje"></param>
        /// <param name="datosResponse"></param>
        public Response(bool status, string mensaje, T datosResponse)
        {
            Status = status;
            Mensaje = mensaje;
            Datos = datosResponse ?? new T();
        }

        public Response(bool status, string mensaje, ErrorCode codigoError)
        {
            Status = status;
            Mensaje = mensaje;
            CodigoError = codigoError;
        }
    }

    /// <summary>
    /// Response estandar para cualquier peticion a la API de SIAC
    /// </summary>
    public class Response
    {
        /// <summary>
        /// indita si el proceso fue satisfactorio o no
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Mensaje de Response
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Resultado de la petición
        /// </summary>
        public object Datos { get; set; }

        public ErrorCode CodigoError { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Response()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="status"></param>
        /// <param name="mensaje"></param>
        public Response(bool status, string mensaje)
        {
            Status = status;
            Mensaje = mensaje;
            Datos = null;
        }

        public Response(bool status, string mensaje, ErrorCode codigoError)
        {
            Status = status;
            Mensaje = mensaje;
            CodigoError = codigoError;
            Datos = null;
        }
    }
}
