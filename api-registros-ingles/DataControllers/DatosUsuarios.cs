using api_registros_ingles.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace api_registros_ingles.DataControllers
{
    public class DatosUsuarios
    {
        private readonly IConfiguration _configuration;

        public DatosUsuarios(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Usuarios> ConsultarTodo()
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            List<Usuarios> datosUsuario = new();
            MySqlConnection connection = new(connectionString);
            MySqlCommand query = new("CALL p_Usuarios_ConsultarTodo()", connection);

            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dt);
                connection.Close();

                datosUsuario = (from DataRow row in dt.Rows
                                select new Usuarios
                                {
                                    ID = (int)row["ID"],
                                    Nombre = row["Nombre"].ToString(),
                                    Contraseña = row["Contraseña"].ToString(),
                                }).ToList();

                return datosUsuario;
            }
            catch (Exception)
            {
                connection.Close();
                return datosUsuario;
            }
        }

        public string ConsultarHash(string Nombre)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_Usuarios_ConsultarHash('{0}')", Nombre), connection);
            string? resultado = "";
            try
            {
                connection.Open();
                object res = query.ExecuteScalar();
                if (res != null)
                {
                    resultado = res.ToString();
                }
                connection.Close();
                return resultado;
            }
            catch (Exception)
            {
                connection.Close();
                return resultado;
            }
        }

        public bool ActualizarNombre(string Nombre, int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_Usuarios_ActualizarNombre('{0}', {1})", Nombre, ID), connection);
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

        public bool ActualizarContraseña(string Contraseña, int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_Usuarios_ActualizarContraseña('{0}', {1})", Contraseña, ID), connection);
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
