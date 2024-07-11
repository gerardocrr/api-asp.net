using api_registros_ingles.DataControllers;
using Microsoft.AspNetCore.Mvc;

namespace api_registros_ingles.Controllers
{
    [ApiController]
    [Route("api")]
    public class EscuelasController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EscuelasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("escuelas/consultar-todo")]
        public JsonResult ConsultarTodo()
        {
            DatosEscuelas datosEscuelas = new(_configuration);
            var datos = datosEscuelas.ConsultarTodo();
            return new JsonResult(datos);
        }

        [HttpGet("escuelas/consultar-escuela")]
        public JsonResult ConsultarEscuela(int ID)
        {
            DatosEscuelas datosEscuelas = new(_configuration);
            var datos = datosEscuelas.ConsultarEscuela(ID);
            return new JsonResult(datos);
        }

        [HttpPost("escuelas/nuevo-registro")]
        public string NuevoRegistro(string Nombre)
        {
            DatosEscuelas datosEscuelas = new(_configuration);
            bool resultado = datosEscuelas.NuevoRegistro(Nombre);
            if (resultado == true)
            {
                return "Datos almacenados correctamente.";
            }
            else
            {
                return "Ocurrio un error al almacenar los datos.";
            }
        }

        [HttpPut("escuelas/actualizar-registro")]
        public string ActualizarRegistro(string Nombre, int ID)
        {
            DatosEscuelas datosEscuelas = new(_configuration);
            bool resultado = datosEscuelas.ActualizarRegistro(Nombre, ID);
            if (resultado == true)
            {
                return "Datos actualizados correctamente.";
            }
            else
            {
                return "Ocurrio un error al actualizar los datos.";
            }
        }
    }
}
