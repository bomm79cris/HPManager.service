using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HPManager.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacionesController : ControllerBase
    {
        private readonly IObservacionesManager _observacionesManager;
        public ObservacionesController(IObservacionesManager observacionesManager) {
            _observacionesManager = observacionesManager;
        }
        [HttpGet("observaciones/{estudianteID}")]
        [ProducesResponseType(typeof(IEnumerable<ObservacionesDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetObservationsByEstudianteID(int estudianteID)
        {
            var observaciones = await _observacionesManager.GetObservationsByEstudianteIDAsync(estudianteID);
            return Ok(observaciones);
        }

        [HttpPost("observaciones")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateObservacions([FromBody] SaveObservacionesDto saveObservacionesDto)
        {
            await _observacionesManager.CreateObservationAsync(saveObservacionesDto);
            return Ok();
        }
    }
}
