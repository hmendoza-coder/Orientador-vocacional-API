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

        public PreguntaRepository()
        {
            _connection = new Connection();
        }

        public Pregunta ObtenerPrimerPregunta()
        {
            StringBuilder query = new StringBuilder()
                .Append("SELECT * FROM Pregunta ")
                .Append("order by rand() limit 1");

            return _connection.CreateDataTable(query.ToString()).ToList<Pregunta>().FirstOrDefault();
        }

        public bool Exists(int idPregunta)
        {
            string query = $"SELECT COUNT(*) FROM pregunta WHERE id_pregunta = {idPregunta}";
            return _connection.ExecuteScalar(query).NotNullToString().ToInt() > 0;
        }

        public Pregunta ObtenerSiguientePregunta(int idArea)
        {
            StringBuilder query = new StringBuilder()
                .AppendLine("SELECT p.* FROM pregunta p ")
                .AppendLine("LEFT JOIN respuesta r ")
                .AppendLine("USING(id_pregunta) ")
                .AppendLine("WHERE r.id_pregunta is null ")
                .AppendLine($"AND id_area = {idArea}");

            return _connection.CreateDataTable(query.ToString()).ToList<Pregunta>().FirstOrDefault();
        }
        
        public int ContarTotalPreguntas()
        {
            string query = "SELECT COUNT(*) FROM pregunta";
            return _connection.ExecuteScalar(query).NotNullToString().ToInt();
        }
    }
}
