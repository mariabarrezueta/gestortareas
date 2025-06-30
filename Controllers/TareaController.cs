using Microsoft.AspNetCore.Mvc;
using Gestortareas.DTOs;
using Gestortareas.Interfaces;
using Gestortareas.Models;

namespace Gestortareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        private readonly ITareaService _service;

        public TareaController(ITareaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tareas = await _service.ObtenerTodas();
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tarea = await _service.ObtenerPorId(id);
            if (tarea == null) return NotFound();
            return Ok(tarea);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TareaDTO dto)
        {
            var nuevaTarea = new Tarea
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                FechaLimite = dto.FechaLimite,
                Completada = dto.Completada,
                Categoria = dto.Categoria,
                Prioridad = (Prioridad)dto.Prioridad
            };

            await _service.Crear(nuevaTarea);
            return CreatedAtAction(nameof(GetById), new { id = nuevaTarea.Id }, nuevaTarea);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TareaDTO dto)
        {
            var tareaExistente = await _service.ObtenerPorId(id);
            if (tareaExistente == null) return NotFound();

            tareaExistente.Titulo = dto.Titulo;
            tareaExistente.Descripcion = dto.Descripcion;
            tareaExistente.FechaLimite = dto.FechaLimite;
            tareaExistente.Completada = dto.Completada;
            tareaExistente.Categoria = dto.Categoria;
            tareaExistente.Prioridad = (Prioridad)dto.Prioridad;

            await _service.Actualizar(tareaExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tarea = await _service.ObtenerPorId(id);
            if (tarea == null) return NotFound();

            await _service.Eliminar(id);
            return NoContent();
        }
    }
}
