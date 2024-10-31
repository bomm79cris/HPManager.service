using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HPManager.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientosController : ControllerBase
    {
        private readonly ITratamientosManager _tratamientosManager;
        public TratamientosController(ITratamientosManager tratamientosManager) {
            _tratamientosManager = tratamientosManager;
        }


        [HttpGet("{estudianteID}")]
        [ProducesResponseType(typeof(IEnumerable<GetTratamientoDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetObservationsByEstudianteID(int estudianteID)
        {
            var tratamientos = await _tratamientosManager.GetTratamientosByEstudianteID(estudianteID);
            return Ok(tratamientos);
        }
        [HttpPut("{tratamientoID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CambioEstadoTratamiento(int tratamientoID, [FromQuery] int estadoID)
        {
            await _tratamientosManager.CambiarEstadoDeUnTratamientoAsync(estadoID, tratamientoID);
            return Ok();
        }
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CrearTratamientoParaUnEstudiante([FromBody] NewTratamientoDto tratamiento)
        {
            await _tratamientosManager.CrearTratamientoParaUnEstudiante(tratamiento);
            return Ok();
        }
        [HttpPut("update/{tratamientoID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> EditarTratamientoEstudiante([FromBody] UpdateTratamientoDto tratamiento, int tratamientoID)
        {
            await _tratamientosManager.EditarTratamientoParaUnEstudiante(tratamiento, tratamientoID);
            return Ok();
        }
        [HttpDelete("{tratamientoID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeteleTratamientoParaUnEstudiante (int tratamientoID)
        {
            await _tratamientosManager.DeleteTratamientoParaUnEstudiante(tratamientoID);
            return Ok();
        }

    }
}
