using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.DTOs;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Repositories
{
    public class DomicilioRepository
    {
        private readonly Connection _connection;

        public DomicilioRepository()
        {
            _connection = new Connection();
        }

        public void Insert(Domicilio domicilio)
        {
            string query = $"INSERT INTO domicilio VALUES(null,{domicilio.IdPersona}, '{domicilio.IdEstado}', '{domicilio.IdMunicipio}', {domicilio.IdColonia})";
            _connection.ExecuteNonQuery(query);
        }
    }
}
