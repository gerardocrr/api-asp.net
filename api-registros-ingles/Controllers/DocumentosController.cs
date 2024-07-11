using api_registros_ingles.DataControllers;
using Microsoft.AspNetCore.Mvc;

namespace api_registros_ingles.Controllers
{
    [ApiController]
    [Route("api")]
    public class DocumentosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DocumentosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("documentos/consultar-todo")]
        public JsonResult ConsultarTodo()
        {
            DatosDocumentos datosDocumentos = new(_configuration);
            var datos = datosDocumentos.ConsultarTodo();
            return new JsonResult(datos);
        }

        [HttpGet("documentos/consultar-documento")]
        public JsonResult ConsultarDocumento(int ID)
        {
            DatosDocumentos datosDocumentos = new(_configuration);
            var datos = datosDocumentos.ConsultarDocumento(ID);
            return new JsonResult(datos);
        }

        [HttpPost("documentos/nuevo-registro")]
        public string NuevoRegistro(string Nombre)
        {
            DatosDocumentos datosDocumentos = new(_configuration);
            bool resultado = datosDocumentos.NuevoRegistro(Nombre);
            if (resultado == true)
            {
                return "Datos almacenados correctamente.";
            }
            else
            {
                return "Ocurrio un error al almacenar los datos.";
            }
        }

        [HttpPut("documentos/actualizar-registro")]
        public string ActualizarRegistro(string Nombre, int ID)
        {
            DatosDocumentos datosDocumentos = new(_configuration);
            bool resultado = datosDocumentos.ActualizarRegistro(Nombre, ID);
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
