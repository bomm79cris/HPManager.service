using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HPManager.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioManager _usuarioManager;
        public UserController(IUsuarioManager usuarioManager)
        {
            _usuarioManager = usuarioManager;
        }

        [HttpGet("{padreID}")]
        [ProducesResponseType(typeof(IEnumerable<EstudianteDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetEstudiantesByPadreId(int padreID)
        {
           var estudiantes = await _usuarioManager.GetEstudiantesByPadresId(padreID);
           return Ok(estudiantes);
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EstudianteDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetEstudiantesAll()
        {
            var estudiantes = await _usuarioManager.GetEstudiantesAllAsync();
            return Ok(estudiantes);
        }
        [HttpGet("estudiante/{estudianteID}")]
        [ProducesResponseType(typeof(EstudianteDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetEstudianteByID(int estudianteID)
        {
            var estudiantes = await _usuarioManager.GetEstudianteById(estudianteID);
            return Ok(estudiantes);
        }
    }
}
