using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Repositories
{
    public class AreaRepository
    {
        private readonly Connection _connection;

        public AreaRepository()
        {
            _connection = new Connection();
        }

        public Area ObtenerArea(int idPregunta)
        {
            string query = $"SELECT * FROM area WHERE id_pregunta = {idPregunta}";
            return _connection.CreateDataTable(query).ToList<Area>().FirstOrDefault();
        }
    }
}
