using Gestortareas.Models;

namespace Gestortareas.Interfaces
{
    public interface ITareaService
    {
        Task<IEnumerable<Tarea>> ObtenerTodas();
        Task<Tarea?> ObtenerPorId(int id);
        Task Crear(Tarea nuevaTarea);
        Task Actualizar(Tarea tareaActualizada);
        Task Eliminar(int id);
    }
}
