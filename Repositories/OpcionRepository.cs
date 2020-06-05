using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.Repositories
{
    public class OpcionRepository
    {
        private readonly Connection _connection;

        public OpcionRepository()
        {
            _connection = new Connection();
        }

        public bool Exists(int idOpcion)
        {
            string query = $"SELECT COUNT(*) FROM opcion WHERE id_opcion = {idOpcion}";
            return _connection.ExecuteScalar(query).NotNullToString().ToInt() > 0;
        }
    }
}
