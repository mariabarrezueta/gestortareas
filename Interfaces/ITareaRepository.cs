using Gestortareas.Models;

namespace Gestortareas.Interfaces
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> GetAllAsync();
        Task<Tarea?> GetByIdAsync(int id);
        Task AddAsync(Tarea tarea);
        Task UpdateAsync(Tarea tarea);
        Task DeleteAsync(int id);
    }
}
