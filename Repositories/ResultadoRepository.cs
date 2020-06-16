using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.DTOs;
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

        public List<ResultadoHistoricoDtOut> ObtenerResultadosHistorico(int idPersona)
        {
            StringBuilder query = new StringBuilder()
                .AppendLine("SELECT cast(fecha_inicio as char) as fecha, c.nombre as carrera, afinidad FROM sesion s ")
                .AppendLine("inner join persona p ")
                .AppendLine("using(id_persona) ")
                .AppendLine("inner join resultado r ")
                .AppendLine("using(id_sesion) ")
                .AppendLine("inner join carrera c ")
                .AppendLine("using(id_carrera) ")
                .AppendLine($"WHERE id_persona = {idPersona}")
                .AppendLine("ORDER BY afinidad desc");
            return _connection.CreateDataTable(query.ToString()).ToList<ResultadoHistoricoDtOut>();
        }
    }
}
