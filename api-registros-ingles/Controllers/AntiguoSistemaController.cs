using api_registros_ingles.DataControllers;
using Microsoft.AspNetCore.Mvc;

namespace api_registros_ingles.Controllers
{
    [ApiController]
    [Route("api")]
    public class AntiguoSistemaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AntiguoSistemaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("antiguo-sistema/consultar-todo")]
        public JsonResult ConsultarTodo()
        {
            DatosAntiguoSistema antiguoSistema = new(_configuration);
            var datos = antiguoSistema.ConsultarTodo();
            return new JsonResult(datos);
        }

        [HttpGet("antiguo-sistema/consultar-alumno")]
        public JsonResult ConsultarAlumno(int ID)
        {
            DatosAntiguoSistema antiguoSistema = new(_configuration);
            var datos = antiguoSistema.ConsultarAlumno(ID);
            return new JsonResult(datos);
        }

        [HttpPost("antiguo-sistema/nuevo-registro")]
        public string NuevoRegistro(string Folio_acta, string Num_control, string Nombre, string Calificacion, string Carrera, string Semestre, string Documento_entregado, string Emite, string Ciclo, string Fecha_entrega_acta, string Sexo)
        {
            DatosAntiguoSistema antiguoSistema = new(_configuration);
            bool resultado = antiguoSistema.NuevoRegistro(Folio_acta, Num_control, Nombre, Calificacion, Carrera, Semestre, Documento_entregado, Emite, Ciclo, Fecha_entrega_acta, Sexo);
            if (resultado == true)
            {
                return "Datos almacenados correctamente.";
            }
            else
            {
                return "Ocurrio un error al almacenar los datos.";
            }
        }

        [HttpPut("antiguo-sistema/actualizar-registro")]
        public string ActualizarRegistro(string Folio_acta, string Num_control, string Nombre, string Calificacion, string Carrera, string Semestre, string Documento_entregado, string Emite, string Ciclo, string Fecha_entrega_acta, string Sexo, int ID)
        {
            DatosAntiguoSistema antiguoSistema = new(_configuration);
            bool resultado = antiguoSistema.ActualizarRegistro(Folio_acta, Num_control, Nombre, Calificacion, Carrera, Semestre, Documento_entregado, Emite, Ciclo, Fecha_entrega_acta, Sexo, ID);
            if (resultado == true)
            {
                return "Datos actualizados correctamente.";
            }
            else
            {
                return "Ocurrio un error al actualizar los datos.";
            }
        }

        [HttpDelete("antiguo-sistema/eliminar-registro")]
        public string EliminarRegistro(int ID)
        {
            DatosAntiguoSistema antiguoSistema = new(_configuration);
            bool resultado = antiguoSistema.EliminarRegistro(ID);
            if (resultado == true)
            {
                return "Datos eliminados correctamente.";
            }
            else
            {
                return "Ocurrio un error al eliminar los datos.";
            }
        }
    }
}
