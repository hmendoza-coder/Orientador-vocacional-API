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
    }
}
