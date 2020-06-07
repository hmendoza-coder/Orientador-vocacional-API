using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Repositories
{
    public class RespuestaRepository
    {
        private readonly Connection _connection;

        public RespuestaRepository()
        {
            _connection = new Connection();
        }

        public bool TieneRespuestas(string idSesion)
        {
            string query = $"SELECT COUNT(*) FROM respuesta WHERE id_sesion ='{idSesion}'";
            return _connection.ExecuteScalar(query).NotNullToString().ToInt() > 0;
        }

        public Respuesta ObtenerUltimaRespuesta(string sesion)
        {
            string query =
                $"SELECT * FROM respuesta WHERE id_sesion = '{sesion}' ORDER BY id_respuesta desc LIMIT 1";
            return _connection.CreateDataTable(query).ToList<Respuesta>().FirstOrDefault();
        }

        public void GuardarRespuesta(Respuesta respuesta)
        {
            string query = $"INSERT INTO respuesta VALUES(null,'{respuesta.IdSesion}',{respuesta.IdPregunta},{respuesta.IdOpcion})";
            _connection.ExecuteNonQuery(query);
        }

        public int ContarRespuestas(string idSesion)
        {
            string query = $"SELECT COUNT(*) FROM respuesta WHERE id_sesion ='{idSesion}'";
            return _connection.ExecuteScalar(query).NotNullToString().ToInt();
        }

    }
}
