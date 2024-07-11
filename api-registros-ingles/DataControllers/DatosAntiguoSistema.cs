using api_registros_ingles.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace api_registros_ingles.DataControllers
{    
    public class DatosAntiguoSistema
    {
        private readonly IConfiguration _configuration;

        public DatosAntiguoSistema(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<AlumnosAntiguoSistema> ConsultarTodo()
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            List<AlumnosAntiguoSistema> datosAntiguoSistema = new();
            MySqlConnection connection = new(connectionString);
            MySqlCommand query = new("CALL p_AntiguoSistema_ConsultarTodo()", connection);

            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dt);
                connection.Close();

                datosAntiguoSistema = (from DataRow row in dt.Rows
                                     select new AlumnosAntiguoSistema
                                     {
                                         ID = (int)row["ID"],
                                         Folio_acta = row["Folio_acta"].ToString(),
                                         Num_control = row["Num_control"].ToString(),
                                         Nombre = row["Nombre"].ToString(),
                                         Calificacion = row["Calificacion"].ToString(),
                                         Carrera = row["Carrera"].ToString(),
                                         Semestre = row["Semestre"].ToString(),
                                         Documento_entregado = row["Documento_entregado"].ToString(),
                                         Emite = row["Emite"].ToString(),
                                         Ciclo = row["Ciclo"].ToString(),
                                         Fecha_entrega_acta = row["Fecha_entrega_acta"].ToString(),
                                         Sexo = row["Sexo"].ToString()
                                     }).ToList();

                return datosAntiguoSistema;
            }
            catch (Exception)
            {
                connection.Close();
                return datosAntiguoSistema;
            }
        }

        public List<AlumnosAntiguoSistema> ConsultarAlumno(int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            List<AlumnosAntiguoSistema> datosAlumno = new();
            MySqlConnection connection = new(connectionString);
            MySqlCommand query = new MySqlCommand(String.Format("CALL p_AntiguoSistema_ConsultarAlumno({0})", ID), connection);

            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dt);
                connection.Close();

                datosAlumno = (from DataRow row in dt.Rows
                                       select new AlumnosAntiguoSistema
                                       {
                                           ID = (int)row["ID"],
                                           Folio_acta = row["Folio_acta"].ToString(),
                                           Num_control = row["Num_control"].ToString(),
                                           Nombre = row["Nombre"].ToString(),
                                           Calificacion = row["Calificacion"].ToString(),
                                           Carrera = row["Carrera"].ToString(),
                                           Semestre = row["Semestre"].ToString(),
                                           Documento_entregado = row["Documento_entregado"].ToString(),
                                           Emite = row["Emite"].ToString(),
                                           Ciclo = row["Ciclo"].ToString(),
                                           Fecha_entrega_acta = row["Fecha_entrega_acta"].ToString(),
                                           Sexo = row["Sexo"].ToString()
                                       }).ToList();

                return datosAlumno;
            }
            catch (Exception)
            {
                connection.Close();
                return datosAlumno;
            }
        }

        public bool NuevoRegistro(string Folio_acta, string Num_control, string Nombre, string Calificacion, string Carrera, string Semestre, string Documento_entregado, string Emite, string Ciclo,  string Fecha_entrega_acta, string Sexo)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_AntiguoSistema_NuevoRegistro(null, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')", Folio_acta, Num_control, Nombre, Calificacion, Carrera, Semestre, Documento_entregado, Emite, Ciclo, Fecha_entrega_acta, Sexo), connection);
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

        public bool ActualizarRegistro(string Folio_acta, string Num_control, string Nombre, string Calificacion, string Carrera, string Semestre, string Documento_entregado, string Emite, string Ciclo, string Fecha_entrega_acta, string Sexo, int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_AntiguoSistema_ActualizarRegistro('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', {11})", Folio_acta, Num_control, Nombre, Calificacion, Carrera, Semestre, Documento_entregado, Emite, Ciclo, Fecha_entrega_acta, Sexo, ID), connection);
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

        public bool EliminarRegistro(int ID)
        {
            string? connectionString = _configuration.GetConnectionString("MySqlConnection");
            MySqlConnection connection = new(connectionString);
            var query = new MySqlCommand(String.Format("CALL p_AntiguoSistema_EliminarRegistro({0})", ID), connection);
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
