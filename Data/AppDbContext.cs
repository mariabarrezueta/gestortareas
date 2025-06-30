using Microsoft.EntityFrameworkCore;
using Gestortareas.Models;

namespace Gestortareas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Tarea> Tareas => Set<Tarea>();
    }
}
