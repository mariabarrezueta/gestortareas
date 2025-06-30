namespace Gestortareas.DTOs
{
    public class TareaDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaLimite { get; set; }
        public bool Completada { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public int Prioridad { get; set; }  // 0: Baja, 1: Media, 2: Alta
    }
}
