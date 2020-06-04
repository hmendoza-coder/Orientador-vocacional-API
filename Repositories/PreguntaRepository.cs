using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Repositories
{
    public class PreguntaRepository
    {
        private readonly Connection _connection;
        private readonly RespuestaRepository _respuestaRepository;
        private readonly SesionRepository _sesionRepository;

        public PreguntaRepository()
        {
            _connection = new Connection();
            _respuestaRepository = new RespuestaRepository();
            _sesionRepository = new SesionRepository();
        }

        public Pregunta ObtenerPrimerPregunta()
        {
            StringBuilder query = new StringBuilder()
                .Append("SELECT * FROM Pregunta ")
                .Append("order by rand() limit 1");

            return _connection.CreateDataTable(query.ToString()).ToList<Pregunta>().FirstOrDefault();
        }

        public Pregunta ObtenerPregunta(string idSesion)
        {
            var sesion = _sesionRepository.ObtenerSesion(idSesion);
            var pregunta = new Pregunta();

            if (!_respuestaRepository.TieneRespuestas(sesion.idPersona))
                return pregunta = ObtenerPrimerPregunta();

            var ultimaRespuesta = _respuestaRepository.ObtenerUltimaRespuesta(idSesion);

            if (ultimaRespuesta.IdRespuesta.Equals(OpcionRespuesta.Nada))
            {
                //CAMBIAR AREA, EXCLUYENDO EL AREA ACTUAL
            }
            else
            {
                //QUEDARSE EN EL AREA ACTUAL
            }

            return pregunta;
        }

    }
}
