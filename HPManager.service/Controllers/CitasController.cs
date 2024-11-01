using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HPManager.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController:ControllerBase
    {
        public readonly ICitasManager _citasManager;
        public CitasController(ICitasManager citasManager)
        {
            _citasManager = citasManager;
        }

        [HttpGet("estudiante/{estudianteID}")]
        [ProducesResponseType(typeof(IEnumerable<GetCitasDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetCitasByEstudianteId(int estudianteID)
        {
            var citas = await _citasManager.GetCitasByEstudianteIdAsync(estudianteID);
            return Ok(citas);
        }
        [HttpGet("psicologo/{psicologoID}")]
        [ProducesResponseType(typeof(IEnumerable<GetCitasDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetCitasByPsicologoId(int psicologoID)
        {
            var citas = await _citasManager.GetCitasByPsicologoIdAsync(psicologoID);
            return Ok(citas);
        }
        [HttpDelete("{citaID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteCitabByID(int citaID)
        {
            await _citasManager.DeleteCitasByIdAsync(citaID);
            return Ok();
        }
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateNewCita([FromBody] CitasDto newCita)
        {
            await _citasManager.CreateNewCitaAsync(newCita);
            return Ok();
        }
        [HttpPut("state-cita/{citaID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CambiarEstadoDeCita(int citaID, [FromQuery] int newEstadoID)
        {
            await _citasManager.CambiarEstadoCitaAsync(citaID, newEstadoID);
            return Ok();
        }
        [HttpPut("{citaID}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateCita(int citaID, [FromBody] UpdateCitaDto updateCita)
        {
            await _citasManager.UpdateCitaByIdAsync(citaID, updateCita);
            return Ok();
        }

    }
}
