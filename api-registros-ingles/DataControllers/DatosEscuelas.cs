using api_registros_ingles.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace api_registros_ingles.DataControllers
{
    public class DatosEscuelas
    {
        private readonly IConfiguration _configuration;

        public DatosEscuelas(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Escuelas> ConsultarTodo()
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            List<Escuelas> datosEscuela = new();
            MySqlConnection connection = new(connectionString);
            MySqlCommand query = new("CALL p_Escuelas_ConsultarTodo()", connection);

            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dt);
                connection.Close();

                datosEscuela = (from DataRow row in dt.Rows
                                  select new Escuelas
                                  {
                                      ID = (int)row["ID"],
                                      Nombre = row["Nombre"].ToString()
                                  }).ToList();

                return datosEscuela;
            }
            catch (Exception)
            {
                connection.Close();
                return datosEscuela;
            }
        }

        public List<Escuelas> ConsultarEscuela(int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            List<Escuelas> datosEscuela = new();
            MySqlConnection connection = new(connectionString);
            MySqlCommand query = new MySqlCommand(String.Format("CALL p_Escuelas_ConsultarEscuela({0})", ID), connection);

            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dt);
                connection.Close();

                datosEscuela = (from DataRow row in dt.Rows
                                select new Escuelas
                                {
                                    ID = (int)row["ID"],
                                    Nombre = row["Nombre"].ToString()
                                }).ToList();

                return datosEscuela;
            }
            catch (Exception)
            {
                connection.Close();
                return datosEscuela;
            }
        }

        public bool NuevoRegistro(string Nombre)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_Escuelas_NuevoRegistro(null, '{0}')", Nombre), connection);
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
            var query = new MySqlCommand(String.Format("CALL p_Escuelas_ActualizarRegistro('{0}', {1})", Nombre, ID), connection);
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
