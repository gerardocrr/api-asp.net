using api_registros_ingles.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace api_registros_ingles.DataControllers
{
    public class DatosDocumentos
    {
        private readonly IConfiguration _configuration;

        public DatosDocumentos(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Documentos> ConsultarTodo()
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            List<Documentos> datosDocuemnto = new();
            MySqlConnection connection = new(connectionString);
            MySqlCommand query = new("CALL p_Documentos_ConsultarTodo()", connection);

            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dt);
                connection.Close();

                datosDocuemnto = (from DataRow row in dt.Rows
                                select new Documentos
                                {
                                    ID = (int)row["ID"],
                                    Nombre = row["Nombre"].ToString()
                                }).ToList();

                return datosDocuemnto;
            }
            catch (Exception)
            {
                connection.Close();
                return datosDocuemnto;
            }
        }

        public List<Documentos> ConsultarDocumento(int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            List<Documentos> datosDocumento = new();
            MySqlConnection connection = new(connectionString);
            MySqlCommand query = new MySqlCommand(String.Format("CALL p_Documentos_ConsultarDocumento({0})", ID), connection);

            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dt);
                connection.Close();

                datosDocumento = (from DataRow row in dt.Rows
                                select new Documentos
                                {
                                    ID = (int)row["ID"],
                                    Nombre = row["Nombre"].ToString()
                                }).ToList();

                return datosDocumento;
            }
            catch (Exception)
            {
                connection.Close();
                return datosDocumento;
            }
        }

        public bool NuevoRegistro(string Nombre)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_Documentos_NuevoRegistro(null, '{0}')", Nombre), connection);
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
            var query = new MySqlCommand(String.Format("CALL p_Documentos_ActualizarRegistro('{0}', {1})", Nombre, ID), connection);
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
