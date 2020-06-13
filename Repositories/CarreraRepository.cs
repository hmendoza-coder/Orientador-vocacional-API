using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Repositories
{
    public class CarreraRepository
    {
        private readonly Connection _connection;

        public CarreraRepository()
        {
            _connection = new Connection();
        }

        public List<Carrera> ObtenerCarreras(int idArea)
        {
            StringBuilder query = new StringBuilder()
                .AppendLine("SELECT * FROM carrera c inner join area_carrera ac using(id_carrera) ")
                .AppendLine($"WHERE id_area ={idArea};");
            return _connection.CreateDataTable(query.ToString()).ToList<Carrera>();
        }


    }
}
