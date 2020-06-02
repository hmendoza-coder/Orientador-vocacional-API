using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.DTOs;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Repositories
{
    public class CredencialRepository
    {
        private readonly Connection _connection;

        public CredencialRepository()
        {
            _connection = new Connection();
        }

        public Credencial.Estatus VerificarCredencial(CredencialDtoIn credencial)
        {
            string query = $"SELECT count(*) FROM persona WHERE id_persona = '{credencial.IdPersona}'";

            if (_connection.ExecuteScalar(query).NotNullToString().ToInt() < 1)
                return Credencial.Estatus.UsuarioNoEncontrado;

            query = $"SELECT * FROM persona p inner join credencial c using(id_persona) where password = '{credencial.Password}'";
            var registros = _connection.ExecuteScalar(query).NotNullToString().ToInt();

            if (registros < 1)
                return Credencial.Estatus.PasswordErronea;

            return registros.Equals(1) ? Credencial.Estatus.Ok : Credencial.Estatus.Error;
        }
    }
}
