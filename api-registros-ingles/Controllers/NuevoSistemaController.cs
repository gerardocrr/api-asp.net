using api_registros_ingles.DataControllers;
using Microsoft.AspNetCore.Mvc;

namespace api_registros_ingles.Controllers
{
    [ApiController]
    [Route("api")]
    public class NuevoSistemaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public NuevoSistemaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("nuevo-sistema/consultar-todo")]
        public JsonResult ConsultarTodo()
        {
            DatosNuevoSistema nuevoSistema = new(_configuration);
            var datos = nuevoSistema.ConsultarTodo();
            return new JsonResult(datos);
        }

        [HttpGet("nuevo-sistema/consultar-alumno")]
        public JsonResult ConsultarAlumno(int ID)
        {
            DatosNuevoSistema nuevoSistema = new(_configuration);
            var datos = nuevoSistema.ConsultarAlumno(ID);
            return new JsonResult(datos);
        }

        [HttpGet("nuevo-sistema/consultar-folio")]
        public JsonResult ConsultarFolio()
        {
            DatosNuevoSistema nuevoSistema = new(_configuration);
            var datos = nuevoSistema.ConsultarFolio();
            return new JsonResult(datos);
        }

        [HttpPost("nuevo-sistema/nuevo-registro")]
        public string NuevoRegistro(string Folio, string Nombre, string No_control, int CarreraID, int Documento_entregadoID, string Nivel_ingles, int Escuela_certificadoraID, string Recibido_de_CE, string Puntaje, string Sexo, string Fecha_constancia_generada)
        {
            DatosNuevoSistema nuevoSistema = new(_configuration);
            bool resultado = nuevoSistema.NuevoRegistro(Folio, Nombre, No_control, CarreraID, Documento_entregadoID, Nivel_ingles, Escuela_certificadoraID, Recibido_de_CE, Puntaje, Sexo, Fecha_constancia_generada);
            if (resultado == true)
            {
                return "Datos almacenados correctamente.";
            }
            else
            {
                return "Ocurrio un error al almacenar los datos.";
            }
        }

        [HttpPut("nuevo-sistema/actualizar-registro")]
        public string ActualizarRegistro(string Nombre, string No_control, int CarreraID, int Documento_entregadoID, string Nivel_ingles, int Escuela_certificadoraID, string Puntaje, string Sexo, int ID)
        {
            DatosNuevoSistema nuevoSistema = new(_configuration);
            bool resultado = nuevoSistema.ActualizarRegistro(Nombre, No_control, CarreraID, Documento_entregadoID, Nivel_ingles, Escuela_certificadoraID, Puntaje, Sexo, ID);
            if (resultado == true)
            {
                return "Datos actualizados correctamente.";
            }
            else
            {
                return "Ocurrio un error al actualizar los datos.";
            }
        }

        [HttpPut("nuevo-sistema/actualizar-recibido")]
        public string ActualizarRecibido(string Opcion, int ID)
        {
            DatosNuevoSistema nuevoSistema = new(_configuration);
            bool resultado = nuevoSistema.ActualizarRecibido(Opcion, ID);
            if (resultado == true)
            {
                return "Datos actualizados correctamente.";
            }
            else
            {
                return "Ocurrio un error al actualizar los datos.";
            }
        }

        [HttpPut("nuevo-sistema/actualizar-folio")]
        public string ActualizarFolio(string Folio, int ID)
        {
            DatosNuevoSistema nuevoSistema = new(_configuration);
            bool resultado = nuevoSistema.ActualizarFolio(Folio, ID);
            if (resultado == true)
            {
                return "Folio actualizado correctamente.";
            }
            else
            {
                return "Ocurrio un error al actualizar el folio.";
            }
        }

        [HttpPut("nuevo-sistema/actualizar-fecha-constancia")]
        public string ActualizarFechaConstanciaGenerada(string Fecha_constancia_generada, int ID)
        {
            DatosNuevoSistema nuevoSistema = new(_configuration);
            bool resultado = nuevoSistema.ActualizarFechaConstanciaGenerada(Fecha_constancia_generada, ID);
            if (resultado == true)
            {
                return "Fecha actualizada correctamente.";
            }
            else
            {
                return "Ocurrio un error al actualizar la fecha.";
            }
        }
    }
}
