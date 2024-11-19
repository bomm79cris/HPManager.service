using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HPManager.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComportamientoController : ControllerBase
    {
        private readonly IComportamientosManager _comportamientosManager;

        public ComportamientoController(IComportamientosManager comportamientosManager)
        {
            _comportamientosManager = comportamientosManager;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Comportamiento), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CrearComportamiento([FromBody] SaveComportamientoDto comportamiento)
        {
            var result = await _comportamientosManager.CrearComportamientoAsync(comportamiento);
            return Ok(result);
        }

        [HttpGet("estudiante/{estudianteId}")]
        [ProducesResponseType(typeof(IEnumerable<ComportamientoDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObtenerComportamientosPorEstudiante(int estudianteId, [FromQuery] int userId)
        {
            var comportamientos = await _comportamientosManager.ObtenerComportamientosPorEstudianteAsync(estudianteId, userId);
            return Ok(comportamientos);
        }

        [HttpPut("{idComportamiento}")]
        [ProducesResponseType(typeof(Comportamiento), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateComportamiento(int idComportamiento, [FromBody] string newObservation)
        {
            var updatedComportamiento = await _comportamientosManager.UpdateComportamiento(idComportamiento, newObservation);
            return Ok(updatedComportamiento);
        }

        [HttpDelete("{idComportamiento}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteComportamiento(int idComportamiento)
        {
            await _comportamientosManager.DeleteComportamientoAsync(idComportamiento);
            return NoContent();
        }
    }
}
