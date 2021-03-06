﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Relational;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Repositories
{
    public class SesionRepository
    {
        private readonly Connection _connection;

        public SesionRepository()
        {
            _connection = new Connection();
        }

        public void Insert(Sesion sesion)
        {
            string query = $"INSERT INTO sesion VALUES('{sesion.IdSesion}',{sesion.IdPersona}, '{sesion.FechaInicio.ToMySqlDateTimeFormat()}', null, '{sesion.TestFinalizado}')";
            _connection.ExecuteNonQuery(query);
        }

        public void ActualizarFechaFin(string idSesion)
        {
            string query =
                $"UPDATE sesion SET fecha_fin = '{DateTime.Now.ToMySqlDateTimeFormat()}' WHERE id_sesion = '{idSesion}'";
            _connection.ExecuteNonQuery(query);
        }

        public bool Exists(string idSesion)
        {
            string query = $"SELECT COUNT(*) FROM sesion WHERE id_sesion = '{idSesion}'";
            return _connection.ExecuteScalar(query).NotNullToString().ToInt() > 0;
        }

        public bool TieneFechaFin(string idSesion)
        {
            string query = $"SELECT fecha_fin FROM sesion WHERE id_sesion = '{idSesion}'";
            return !_connection.ExecuteScalar(query).NotNullToString().IsNullOrEmpty();
        }

        public bool SesionValida(string idSesion)
        {
            return Exists(idSesion) && !TieneFechaFin(idSesion);
        }

        public Sesion ObtenerSesion(string idSesion)
        {
            string query = $"SELECT * FROM sesion WHERE id_sesion = '{idSesion}'";
            return _connection.CreateDataTable(query).ToList<Sesion>().FirstOrDefault();
        }

        public void MarcarTestFinalizado(string idSesion)
        {
            string query = $"UPDATE sesion SET Test_Finalizado= 'S' WHERE id_sesion = '{idSesion}'";
            _connection.ExecuteNonQuery(query);
        }

        public bool TestFinalizado(string idSesion)
        {
            string query = $"SELECT test_finalizado FROM sesion where id_sesion ='{idSesion}'";
            return _connection.ExecuteScalar(query).NotNullToString("N").Equals("S");
        }
    }
}
