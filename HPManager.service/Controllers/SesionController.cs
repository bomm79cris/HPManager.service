using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HPManager.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private readonly ISesionesManager _sesionesManager;

        public SesionController(ISesionesManager sesionesManager)
        {
            _sesionesManager = sesionesManager;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Sesion), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CrearSesion([FromBody] SaveSesionesDto nuevaSesion)
        {
            var sesion = await _sesionesManager.CrearSesionAsync(nuevaSesion);
            return Ok(sesion);
        }

        [HttpGet("psicologo/{psicologoId}")]
        [ProducesResponseType(typeof(IEnumerable<SesionesDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObtenerSesionesPorPsicologo(int psicologoId)
        {
            var sesiones = await _sesionesManager.ObtenerSesionesPorPsicologoAsync(psicologoId);
            return Ok(sesiones);
        }

        [HttpGet("estudiante/{estudianteId}")]
        [ProducesResponseType(typeof(IEnumerable<SesionesDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObtenerSesionesPorEstudiante(int estudianteId)
        {
            var sesiones = await _sesionesManager.ObtenerSesionesAEstudianteAsync(estudianteId);
            return Ok(sesiones);
        }

        [HttpPut("{sesionId}")]
        [ProducesResponseType(typeof(Sesion), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> EditarSesion(int sesionId, [FromBody] SaveSesionesDto sesionEditada)
        {
            var sesion = await _sesionesManager.EditarSesionAsync(sesionId, sesionEditada);
            return Ok(sesion);
        }

        [HttpDelete("{sesionId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> EliminarSesion(int sesionId)
        {
            await _sesionesManager.EliminarSesionAsync(sesionId);
            return NoContent();
        }
    }
}
