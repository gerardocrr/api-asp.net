using api_registros_ingles.DataControllers;
using Microsoft.AspNetCore.Mvc;

namespace api_registros_ingles.Controllers
{
    [ApiController]
    [Route("api")]
    public class UsuariosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsuariosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("usuarios/consultar-todo")]
        public JsonResult ConsultarTodo()
        {
            DatosUsuarios datosUsuarios = new(_configuration);
            var datos = datosUsuarios.ConsultarTodo();
            return new JsonResult(datos);
        }

        [HttpGet("usuarios/consultar-hash")]
        public string VerificarDatos(string Nombre)
        {
            DatosUsuarios datosUsuarios = new(_configuration);
            var resultado = datosUsuarios.ConsultarHash(Nombre);
            return resultado;
        }

        [HttpPut("usuarios/actualizar-nombre")]
        public string ActualizarNombre(string Nombre, int ID)
        {
            DatosUsuarios datosUsuarios = new(_configuration);
            bool resultado = datosUsuarios.ActualizarNombre(Nombre, ID);
            if (resultado == true)
            {
                return "Datos actualizados correctamente.";
            }
            else
            {
                return "Ocurrio un error al actualizar los datos.";
            }
        }

        [HttpPut("usuarios/actualizar-contraseña")]
        public string ActualizarContraseña(string Contraseña, int ID)
        {
            DatosUsuarios datosUsuarios = new(_configuration);
            bool resultado = datosUsuarios.ActualizarContraseña(Contraseña, ID);
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
