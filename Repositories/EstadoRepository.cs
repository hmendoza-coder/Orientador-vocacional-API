using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI
{
    public class EstadoRepository
    {
        private readonly Connection _connection;

        public EstadoRepository()
        {
            _connection = new Connection();
        }

        public List<Estado> SelectAll()
        {
            return _connection.CreateDataTable("SELECT * FROM estado").ToList<Estado>();
        }

        public Estado SelectById(string idEstado)
        {
            return _connection.CreateDataTable("SELECT * FROM estado").ToList<Estado>().FirstOrDefault(e => e.IdEstado.Equals(idEstado));
        }

}
}
