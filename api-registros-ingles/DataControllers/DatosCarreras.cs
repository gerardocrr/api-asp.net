﻿using api_registros_ingles.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace api_registros_ingles.DataControllers
{
    public class DatosCarreras
    {
        private readonly IConfiguration _configuration;

        public DatosCarreras(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Carreras> ConsultarTodo()
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            List<Carreras> datosCarrera = new();
            MySqlConnection connection = new(connectionString);
            MySqlCommand query = new("CALL p_Carreras_ConsultarTodo()", connection);

            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dt);
                connection.Close();

                datosCarrera = (from DataRow row in dt.Rows
                                     select new Carreras
                                     {
                                         ID = (int)row["ID"],
                                         Nombre = row["Nombre"].ToString()
                                     }).ToList();

                return datosCarrera;
            }
            catch (Exception)
            {
                connection.Close();
                return datosCarrera;
            }
        }

        public List<Carreras> ConsultarCarrera(int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            List<Carreras> datosCarrera = new();
            MySqlConnection connection = new(connectionString);
            MySqlCommand query = new MySqlCommand(String.Format("CALL p_Carreras_ConsultarCarrera({0})", ID), connection);

            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dt);
                connection.Close();

                datosCarrera = (from DataRow row in dt.Rows
                               select new Carreras
                               {
                                   ID = (int)row["ID"],
                                   Nombre = row["Nombre"].ToString()
                               }).ToList();

                return datosCarrera;
            }
            catch (Exception)
            {
                connection.Close();
                return datosCarrera;
            }
        }

        public bool NuevoRegistro(string Nombre)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_Carreras_NuevoRegistro(null, '{0}')", Nombre), connection);
            try
            {
                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool ActualizarRegistro(string Nombre, int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_Carreras_ActualizarRegistro('{0}', {1})", Nombre, ID), connection);
            try
            {
                connection.Open();
                query.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }
    }
}
