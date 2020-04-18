using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI
{
    public class Connection
    {
        private MySqlConnection _connection;
        private string _server;
        private string _database;
        private string _uid;
        private string _password;

        //Constructor
        public Connection()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            _server = "localhost";
            _database = "orientador_vocacional";
            _uid = "root";
            _password = "xenia";
            string connectionString;
            connectionString = "SERVER=" + _server + ";" + "DATABASE=" +
                               _database + ";" + "UID=" + _uid + ";" + "PASSWORD=" + _password + ";";

            _connection = new MySqlConnection(connectionString);
        }

        public bool ExecuteScalar(string myScalarQuery)
        {
            MySqlCommand myCommand = new MySqlCommand(myScalarQuery, _connection);
            
            myCommand.Connection.Close();
            try
            {
                myCommand.Connection.Open();
                myCommand.ExecuteScalar();
                myCommand.Connection.Close();
                return true;
            }
            catch (Exception)
            {
                myCommand.Connection.Close();
                return false;
            }

        }

        //public async Task<bool> ExecutaSacalarAsync(string myScalarQuery)
        //{
        //    MySqlCommand myCommand = new MySqlCommand(myScalarQuery, _connection);

        //    try
        //    {
        //        myCommand.Connection.OpenAsync();
        //        await myCommand.ExecuteScalarAsync();
        //        myCommand.Connection.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //    finally
        //    {
        //        myCommand.Connection.CloseAsync();
        //    }
        //}


        public void ExecuteNonQuery(string myScalarQuery)
        {
            MySqlCommand myCommand = new MySqlCommand(myScalarQuery, _connection);
            myCommand.Connection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();
        }

        public DataTable CreateDataTable(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            DataTable dt = new DataTable();
            cmd.Connection.Open();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();
            return dt;
        }

        public async Task<DataTable> CreateDataTableAsync(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            DataTable dt = new DataTable();
            await cmd.Connection.OpenAsync();
            dt.Load(await cmd.ExecuteReaderAsync());
            await cmd.Connection.CloseAsync();
            return dt;
        }

    }
}
