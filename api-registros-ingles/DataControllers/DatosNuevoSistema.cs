using api_registros_ingles.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace api_registros_ingles.DataControllers
{
    public class DatosNuevoSistema
    {
        private readonly IConfiguration _configuration;

        public DatosNuevoSistema(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<AlumnosNuevoSistema> ConsultarTodo()
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            List<AlumnosNuevoSistema> datosNuevoSistema = new();
            MySqlConnection connection = new(connectionString);
            MySqlCommand query = new("CALL p_NuevoSistema_ConsultarTodo()", connection);

            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dt);
                connection.Close();

                datosNuevoSistema = (from DataRow row in dt.Rows
                                     select new AlumnosNuevoSistema
                                     {
                                         ID = (int)row["ID"],
                                         Folio = row["Folio"].ToString(),
                                         Nombre = row["Nombre"].ToString(),
                                         Num_control = row["Num_control"].ToString(),
                                         Carrera = row["Carrera"].ToString(),
                                         Documento_entregado = row["Documento_entregado"].ToString(),
                                         Nivel_ingles = row["Nivel_ingles"].ToString(),
                                         Escuela_certificadora = row["Escuela_certificadora"].ToString(),
                                         Recibido_de_CE = row["Recibido_de_CE"].ToString(),
                                         Puntaje = row["Puntaje"].ToString(),
                                         Sexo = row["Sexo"].ToString(),
                                         Fecha_constancia_generada = row["Fecha_constancia_generada"].ToString()
                                     }).ToList();

                return datosNuevoSistema;
            }
            catch (Exception)
            {
                connection.Close();
                return datosNuevoSistema;
            }
        }

        public List<AlumnosNuevoSistema> ConsultarAlumno(int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            List<AlumnosNuevoSistema> datosAlumno = new();
            MySqlConnection connection = new(connectionString);
            MySqlCommand query = new MySqlCommand(String.Format("CALL p_NuevoSistema_ConsultarAlumno({0})", ID), connection);

            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dt);
                connection.Close();

                datosAlumno = (from DataRow row in dt.Rows
                                     select new AlumnosNuevoSistema
                                     {
                                         ID = (int)row["ID"],
                                         Folio = row["Folio"].ToString(),
                                         Nombre = row["Nombre"].ToString(),
                                         Num_control = row["Num_control"].ToString(),
                                         Carrera = row["Carrera"].ToString(),
                                         Documento_entregado = row["Documento_entregado"].ToString(),
                                         Nivel_ingles = row["Nivel_ingles"].ToString(),
                                         Escuela_certificadora = row["Escuela_certificadora"].ToString(),
                                         Recibido_de_CE = row["Recibido_de_CE"].ToString(),
                                         Puntaje = row["Puntaje"].ToString(),
                                         Sexo = row["Sexo"].ToString(),
                                         Fecha_constancia_generada = row["Fecha_constancia_generada"].ToString()
                                     }).ToList();

                return datosAlumno;
            }
            catch (Exception)
            {
                connection.Close();
                return datosAlumno;
            }
        }

        public bool NuevoRegistro(string Folio, string Nombre, string Num_control, int CarreraID, int Documento_entregadoID, string Nivel_ingles, int Escuela_certificadoraID, string Recibido_de_CE, string Puntaje, string Sexo, string Fecha_constancia_generada)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_NuevoSistema_NuevoRegistro(null, '{0}', '{1}', '{2}', {3}, {4}, '{5}', {6}, '{7}', '{8}', '{9}', '{10}')", Folio, Nombre, Num_control, CarreraID, Documento_entregadoID, Nivel_ingles, Escuela_certificadoraID, Recibido_de_CE, Puntaje, Sexo, Fecha_constancia_generada), connection);
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

        public bool ActualizarRegistro(string Nombre, string Num_control, int CarreraID, int Documento_entregadoID, string Nivel_ingles, int Escuela_certificadoraID, string Puntaje, string Sexo, int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_NuevoSistema_ActualizarRegistro('{0}', '{1}', {2}, {3}, '{4}', {5}, '{6}', '{7}', {8})", Nombre, Num_control, CarreraID, Documento_entregadoID, Nivel_ingles, Escuela_certificadoraID, Puntaje, Sexo, ID), connection);
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

        public bool ActualizarRecibido(string Opcion, int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_NuevoSistema_ActualizarRecibido('{0}', {1})", Opcion, ID), connection);
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

        public List<Folios> ConsultarFolio()
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            List<Folios> datosFolio = new();
            MySqlConnection connection = new(connectionString);
            MySqlCommand query = new("CALL p_NuevoSistema_ConsultarFolio()", connection);

            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dt);
                connection.Close();

                datosFolio = (from DataRow row in dt.Rows
                              select new Folios
                              {
                                  Folio = row["Folio"].ToString()
                              }).ToList();

                return datosFolio;
            }
            catch (Exception)
            {
                connection.Close();
                return datosFolio;
            }
        }

        public bool ActualizarFolio(string folio, int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_NuevoSistema_ActualizarFolio('{0}', {1})", folio, ID), connection);
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

        public bool ActualizarFechaConstanciaGenerada(string Fecha, int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_NuevoSistema_ActualizarFechaConstancia('{0}', {1})", Fecha, ID), connection);
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
