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

        public void ActualizarFechaFin(string idSesion)
        {
            string query =
                $"UPDATE sesion SET fecha_fin = '{DateTime.Now.ToMySqlDateTimeFormat()}' WHERE id_sesion = '{idSesion}'";
            _connection.ExecuteNonQuery(query);
        }

        public bool Exists(string idSesion)
        {
            string query = $"SELECT COUNT(*) FROM sesion WHERE id_sesion = '{idSesion}'";
            return _connection.ExecuteScalar(query).NotNullToString().ToInt() > 0;
        }

        public bool TieneFechaFin(string idSesion)
        {
            string query = $"SELECT fecha_fin FROM sesion WHERE id_sesion = '{idSesion}'";
            return !_connection.ExecuteScalar(query).NotNullToString().IsNullOrEmpty();
        }
    }
}
