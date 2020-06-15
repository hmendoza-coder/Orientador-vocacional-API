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
                    "INSERT INTO persona (Nombres, Apellido_p, Apellido_m, Correo, Sexo, Fecha_nacimiento) ")
                .AppendLine(
                    $"VALUES ('{persona.Nombres}','{persona.ApellidoP}','{persona.ApellidoM}', '{persona.Correo}', '{persona.Sexo}', '{persona.FechaNacimiento.ToMysqlDateFormat()}')");
            _connection.ExecuteScalar(query.ToString());
        }

        public int ObtenerIdPersonaByCorreo(string correo)
        {
            string query = $"SELECT Id_persona FROM Persona where correo = '{correo}'";
            return _connection.ExecuteScalar(query).NotNullToString().ToInt();
        }

        public bool Exists(int idPersona)
        {
            string query = $"SELECT COUNT(*) FROM persona WHERE id_persona = {idPersona}";
            return _connection.ExecuteScalar(query).NotNullToString().ToInt() > 0;
        }

        public bool Exists(string correo)
        {
            string query = $"SELECT COUNT(*) FROM persona WHERE correo = {correo}";
            return _connection.ExecuteScalar(query).NotNullToString().ToInt() > 0;
        }

        public void DeleteByCorreo(string correo)
        {
            string query = $"DELETE FROM persona where correo = '{correo}'";
            _connection.ExecuteNonQuery(query);
        }

        public int ObtenerIdPersonaBySesion(string idSesion)
        {
            StringBuilder query = new StringBuilder("SELECT p.id_persona FROM persona p ")
                .AppendLine("INNER JOIN sesion s ")
                .AppendLine("USING(id_persona) ")
                .AppendLine($"WHERE id_sesion = '{idSesion}' ");
            return _connection.ExecuteScalar(query.ToString()).NotNullToString("0").ToInt();
        }
    }
}
