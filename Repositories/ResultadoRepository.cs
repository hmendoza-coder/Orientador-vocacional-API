using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Repositories
{
    public class ResultadoRepository
    {
        private readonly Connection _connection;

        public ResultadoRepository()
        {
            _connection = new Connection();
        }

        public void Insert(Resultado resultado)
        {
            string query =
                $"INSERT INTO resultado VALUES(null,'{resultado.IdSesion}',{resultado.IdCarrera},{resultado.Afinidad})";
            _connection.ExecuteNonQuery(query);
        }
    }
}
