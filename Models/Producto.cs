namespace Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string ProductNombre { get; set; }
        public int ProveedorId { get; set; }
        public decimal? PrecioUnidad { get; set; }
        public string Paquete { get; set; }
        public bool EstaDescontinuado { get; set; }
    }
}
