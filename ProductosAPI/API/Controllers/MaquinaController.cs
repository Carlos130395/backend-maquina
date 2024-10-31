using Microsoft.AspNetCore.Mvc;
using ProductosAPI.Application.Services;
using ProductosAPI.Domain.Entities;

namespace ProductosAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaquinaController : ControllerBase
    {
        private readonly MaquinaService _maquinaService;

        public MaquinaController(MaquinaService maquinaService)
        {
            _maquinaService = maquinaService;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maquina>>> GetAll()
        {
            var maquinas = await _maquinaService.ObtenerTodos();
            return Ok(maquinas);
        }

        // GET: api/Productos/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Maquina>> GetById(Guid id)
        {
            var maquina = await _maquinaService.ObtenerPorId(id);
            return maquina == null ? NotFound() : Ok(maquina);
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<Maquina>> Create(Maquina maquina)
        {
            await _maquinaService.Agregar(maquina);
            return CreatedAtAction(nameof(GetById), new { id = maquina.Id }, maquina);
        }

        // PUT: api/Productos/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, Maquina maquina)
        {
            if (id != maquina.Id) return BadRequest();
            await _maquinaService.Actualizar(maquina);
            return NoContent();
        }

        // DELETE: api/Productos/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _maquinaService.Eliminar(id);
            return NoContent();
        }
    }
}
