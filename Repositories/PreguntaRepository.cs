using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Expressions;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Repositories
{
    public class PreguntaRepository
    {
        private readonly Connection _connection;
        private readonly RespuestaRepository _respuestaRepository;
        private readonly SesionRepository _sesionRepository;
        private readonly AreaRepository _areaRepository;

        public PreguntaRepository()
        {
            _connection = new Connection();
            _respuestaRepository = new RespuestaRepository();
            _sesionRepository = new SesionRepository();
            _areaRepository = new AreaRepository();
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

            if (!_respuestaRepository.TieneRespuestas(sesion.IdPersona))
                return ObtenerPrimerPregunta();

            var ultimaRespuesta = _respuestaRepository.ObtenerUltimaRespuesta(idSesion);
            var area = _areaRepository.ObtenerArea(ultimaRespuesta.IdPregunta);

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

        public bool Exists(int idPregunta)
        {
            string query = $"SELECT COUNT(*) FROM pregunta WHERE id_pregunta = {idPregunta}";
            return _connection.ExecuteScalar(query).NotNullToString().ToInt() > 0;
        }

    }
}
