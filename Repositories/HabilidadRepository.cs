using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Repositories
{
    public class HabilidadRepository
    {
        private readonly Connection _connection;

        public HabilidadRepository()
        {
            _connection = new Connection();
        }

        public List<Habilidad> ContarHabilidadesRespondidas(string idSesion)
        {
            StringBuilder query = new StringBuilder()
                .AppendLine("SELECT h.id_habilidad,h.descripcion, count(*) as cantidad FROM pregunta p ")
                .AppendLine("inner join pregunta_habilidad ph ")
                .AppendLine("using(id_pregunta) ")
                .AppendLine("inner join habilidad h ")
                .AppendLine("using(id_habilidad) ")
                .AppendLine("inner join respuesta r ")
                .AppendLine("using(id_pregunta) ")
                .AppendLine($"WHERE id_sesion = '{idSesion}' ")
                .AppendLine("GROUP BY h.id_habilidad;");

            return _connection.CreateDataTable(query.ToString()).ToList<Habilidad>();
        }

        public List<Habilidad> ContarHabilidadesPotenciales(string idSesion)
        {
            StringBuilder query = new StringBuilder()
                .AppendLine("SELECT h.id_habilidad,h.descripcion, count(*) as cantidad FROM pregunta p ")
                .AppendLine("inner join pregunta_habilidad ph ")
                .AppendLine("using(id_pregunta) ")
                .AppendLine("inner join habilidad h ")
                .AppendLine("using(id_habilidad) ")
                .AppendLine("inner join respuesta r ")
                .AppendLine("using(id_pregunta) ")
                .AppendLine($"WHERE id_sesion = '{idSesion}' and r.id_opcion = {(short)OpcionRespuesta.Mucho}")
                .AppendLine("GROUP BY h.id_habilidad;");

            return _connection.CreateDataTable(query.ToString()).ToList<Habilidad>();
        }
    }
}
