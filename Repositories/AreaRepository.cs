using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.Config;
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
            string query = $"SELECT * FROM area a inner join pregunta p using  (id_area) WHERE id_pregunta = {idPregunta}";
            return _connection.CreateDataTable(query).ToList<Area>().FirstOrDefault();
        }

        public List<Area> ObtenerAreas()
        {
            string query = "SELECT * FROM area";
            return _connection.CreateDataTable(query).ToList<Area>();
        }

        public List<Area> ObtenerAreasDescartadas(string idSesion)
        {
            StringBuilder query = new StringBuilder()
                .AppendLine("select id_area,descripcion from (")
                .AppendLine("SELECT *, count(*) as repeticiones FROM respuesta res ")
                .AppendLine("inner join pregunta p ")
                .AppendLine("using(id_pregunta) ")
                .Append("INNER JOIN area a ")
                .AppendLine("USING(id_area)")
                .AppendLine($"WHERE id_opcion = {(short)OpcionRespuesta.Nada} AND id_sesion = '{idSesion}' ")
                .AppendLine("group by id_area")
                .AppendLine($"having repeticiones >= {ConfiguracionGlobal.INDICE_RECHAZO}) t;");

            return _connection.CreateDataTable(query.NotNullToString()).ToList<Area>();
        }

    }
}
