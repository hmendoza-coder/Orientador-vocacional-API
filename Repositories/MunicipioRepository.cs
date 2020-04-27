using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI
{
    public class MunicipioRepository
    {
        private readonly Connection _connection;

        public MunicipioRepository()
        {
            _connection = new Connection();
        }

        public List<Municipio> SelectAll()
        {
            return _connection.CreateDataTable($"SELECT * FROM {nameof(Municipio)} ").ToList<Municipio>();
        }

        public IEnumerable<Municipio> SelectById(string idEstado)
        {
            return _connection.CreateDataTable($"SELECT * FROM {nameof(Municipio)}").ToList<Municipio>().Where(e => e.IdEstado.Equals(idEstado));
        }

        public IEnumerable<Municipio> SelectById(string idEstado, string idMunicipio)
        {
            return _connection.CreateDataTable($"SELECT * FROM {nameof(Municipio)}").ToList<Municipio>().Where(e => e.IdEstado.Equals(idEstado) && e.IdMunicipio.Equals(idMunicipio));
        }
    }
}
