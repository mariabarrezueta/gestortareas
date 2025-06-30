using Microsoft.EntityFrameworkCore;
using Gestortareas.Data;
using Gestortareas.Interfaces;
using Gestortareas.Models;

namespace Gestortareas.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly AppDbContext _context;

        public TareaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarea>> GetAllAsync()
        {
            return await _context.Tareas.ToListAsync();
        }

        public async Task<Tarea?> GetByIdAsync(int id)
        {
            return await _context.Tareas.FindAsync(id);
        }

        public async Task AddAsync(Tarea tarea)
        {
            await _context.Tareas.AddAsync(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tarea tarea)
        {
            _context.Tareas.Update(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tarea = await GetByIdAsync(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }
    }
}
