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

        private Login ObtenerCredenciales(string correo)
        {
            string query = $"SELECT id_persona,password FROM persona p inner join credencial c using(id_persona) WHERE correo = '{correo}' ";
            return _connection.CreateDataTable(query).ToList<Login>().FirstOrDefault();
        }

        public Credencial.Estatus VerificarCredencial(CredencialDtoIn credencial)
        {
            var login = ObtenerCredenciales(credencial.Correo);

            if(login is null)
                return Credencial.Estatus.UsuarioNoEncontrado;
            
            if (!login.Password.Equals(credencial.Password))
                return Credencial.Estatus.PasswordErronea;

            return Credencial.Estatus.Ok;
        }
    }
}
