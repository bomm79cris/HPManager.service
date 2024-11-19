using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HPManager.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecomandationController : ControllerBase
    {
        private readonly IRecomendacionesManager _recomendacionesManager;

        public RecomandationController(IRecomendacionesManager recomendacionesManager)
        {
            _recomendacionesManager = recomendacionesManager;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Recomendation), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CrearRecomendacion([FromBody] SaveRecomendacionesDto recomendacion)
        {
            var result = await _recomendacionesManager.CrearRecomendacionAsync(recomendacion);
            return Ok(result);
        }

        [HttpGet("docente/{docenteId}")]
        [ProducesResponseType(typeof(IEnumerable<RecomendacionesDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObtenerRecomendacionesPorDocente(int docenteId)
        {
            var recomendaciones = await _recomendacionesManager.ObtenerRecomendacionesPorDocenteAsync(docenteId);
            return Ok(recomendaciones);
        }

        [HttpGet("estudiante/{estudianteId}")]
        [ProducesResponseType(typeof(IEnumerable<RecomendacionesDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObtenerRecomendacionesAEstudiante(int estudianteId)
        {
            var recomendaciones = await _recomendacionesManager.ObtenerRecomendacionesAEstudianteAsync(estudianteId);
            return Ok(recomendaciones);
        }

        [HttpGet("psicologo/{psicologoId}")]
        [ProducesResponseType(typeof(IEnumerable<RecomendacionesDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObtenerRecomendacionesAPsicologo(int psicologoId)
        {
            var recomendaciones = await _recomendacionesManager.ObtenerRecomendacionesAPsicologoAsync(psicologoId);
            return Ok(recomendaciones);
        }
    }
}
