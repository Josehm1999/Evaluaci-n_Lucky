namespace Models
{
    public class OrdenItem
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public decimal PrecioUnidad { get; set; }
        public int Cantidad { get; set; }
    }
}
