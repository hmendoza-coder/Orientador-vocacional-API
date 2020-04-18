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
                    $"VALUES ('{persona.Nombres}','{persona.ApellidoP}','{persona.ApellidoM}', '{persona.Correo}', '{persona.IdCredencial}', '{persona.Sexo}', '{persona.FechaNacimiento.ToMysqlFormat()}', '{persona.IdDomicilio}')");
            _connection.ExecuteScalar(query.ToString());
        }

        //public async Task<Persona> Delete(string idPersona)
        //{
        //    var persona = FindById(idPersona);
        //    return _connection.ExecuteScalar($"DELETE FROM persona where {nameof(Persona.IdPersona)} = {persona.Result.IdPersona}");
        //}

        //public async Task<Persona> FindById(string idPersona)
        //{
        //    return new Persona();
        //}

    }
}
