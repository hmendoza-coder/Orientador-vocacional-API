using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Repositories
{
    public class ColoniaRepository
    {
        private readonly Connection _connection;

        public ColoniaRepository()
        {
            _connection = new Connection();
        }

        public List<Colonia> SelectAll()
        {
            return _connection.CreateDataTable($"SELECT * FROM {nameof(Colonia)} ").ToList<Colonia>();
        }

        public IEnumerable<Colonia> SelectById(string idEstado)
        {
            return _connection.CreateDataTable($"SELECT * FROM {nameof(Colonia)}").ToList<Colonia>().Where(e => e.IdEstado.Equals(idEstado));
        }

        public List<Colonia> SelectById(string idEstado, string idMunicipio)
        {
            StringBuilder query = new StringBuilder()
                .AppendLine($"SELECT * FROM {nameof(Colonia)} ")
                .AppendLine($"WHERE id_estado = '{idEstado}' ")
                .AppendLine($"AND id_municipio = '{idMunicipio}' ");
            return _connection.CreateDataTable(query.ToString()).ToList<Colonia>();
        }

        public IEnumerable<Colonia> SelectById(string idEstado, string idMunicipio, string idColonia)
        {
            return _connection.CreateDataTable($"SELECT * FROM {nameof(Colonia)}").ToList<Colonia>().Where(e => e.IdEstado.Equals(idEstado) && e.IdMunicipio.Equals(idMunicipio));
        }
    }
}
