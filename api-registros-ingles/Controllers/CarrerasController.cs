using api_registros_ingles.DataControllers;
using Microsoft.AspNetCore.Mvc;

namespace api_registros_ingles.Controllers
{
    [ApiController]
    [Route("api")]
    public class CarrerasController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CarrerasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("carreras/consultar-todo")]
        public JsonResult ConsultarTodo()
        {
            DatosCarreras datosCarrera = new(_configuration);
            var datos = datosCarrera.ConsultarTodo();
            return new JsonResult(datos);
        }

        [HttpGet("carreras/consultar-carrera")]
        public JsonResult ConsultarCarrera(int ID)
        {
            DatosCarreras datosCarrera = new(_configuration);
            var datos = datosCarrera.ConsultarCarrera(ID);
            return new JsonResult(datos);
        }

        [HttpPost("carreras/nuevo-registro")]
        public string NuevoRegistro(string Nombre)
        {
            DatosCarreras datosCarrera = new(_configuration);
            bool resultado = datosCarrera.NuevoRegistro(Nombre);
            if (resultado == true)
            {
                return "Datos almacenados correctamente.";
            }
            else
            {
                return "Ocurrio un error al almacenar los datos.";
            }
        }

        [HttpPut("carreras/actualizar-registro")]
        public string ActualizarRegistro(string Nombre, int ID)
        {
            DatosCarreras datosCarrera = new(_configuration);
            bool resultado = datosCarrera.ActualizarRegistro(Nombre, ID);
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
