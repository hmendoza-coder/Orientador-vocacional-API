using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI
{
    public class PersonaRepository
    {
        private readonly Connection _connection;

        public PersonaRepository()
        {
            _connection = new Connection();
        }

        public List<Persona> SelectAll()
        {
            return _connection.CreateDataTable("SELECT * FROM persona").ToList<Persona>();
        }

        public void InsertPersona(Persona persona)
        {
            StringBuilder query = new StringBuilder()
                .AppendLine(
                    "INSERT INTO persona (Nombres, Apellido_p, Apellido_m, Correo, Id_credencial, Sexo, Fecha_nacimiento, Id_domicilio) ")
                .AppendLine(
                    $"VALUES ('{persona.Nombres}','{persona.ApellidoP}','{persona.ApellidoM}', '{persona.Correo}', '{persona.IdCredencial}', '{persona.Sexo}', '{persona.FechaNacimiento.ToMysqlDateFormat()}', '{persona.IdDomicilio}')");
            _connection.ExecuteScalar(query.ToString());
        }

        public int ObtenerIdPersonaByCorreo(string correo)
        {
            string query = $"SELECT Id_persona FROM Persona where correo = '{correo}'";
            return _connection.ExecuteScalar(query).NotNullToString().ToInt();
        }

    }
}
