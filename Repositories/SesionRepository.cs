using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Relational;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Repositories
{
    public class SesionRepository
    {
        private readonly Connection _connection;

        public SesionRepository()
        {
            _connection = new Connection();
        }

        public void Insert(Sesion sesion)
        {
            string query = $"INSERT INTO sesion VALUES('{sesion.IdSesion}',{sesion.idPersona}, '{sesion.FechaInicio.ToMySqlDateTimeFormat()}', null)";
            _connection.ExecuteNonQuery(query);
        }
    }
}
