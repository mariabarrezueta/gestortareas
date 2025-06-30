namespace Gestortareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaLimite { get; set; }
        public bool Completada { get; set; }
        public Prioridad Prioridad { get; set; }
        public string Categoria { get; set; } = string.Empty;
    }

    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }
}
