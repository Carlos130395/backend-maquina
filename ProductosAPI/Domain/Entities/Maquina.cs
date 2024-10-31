namespace ProductosAPI.Domain.Entities
{
    public class Maquina
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Estado { get; set; } = "ACTIVO";
    }
}