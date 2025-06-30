using Gestortareas.Interfaces;
using Gestortareas.Models;

namespace Gestortareas.Services
{
    public class TareaService : ITareaService
    {
        private readonly ITareaRepository _repository;

        public TareaService(ITareaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tarea>> ObtenerTodas()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Tarea?> ObtenerPorId(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task Crear(Tarea nuevaTarea)
        {
            await _repository.AddAsync(nuevaTarea);
        }

        public async Task Actualizar(Tarea tareaActualizada)
        {
            await _repository.UpdateAsync(tareaActualizada);
        }

        public async Task Eliminar(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
