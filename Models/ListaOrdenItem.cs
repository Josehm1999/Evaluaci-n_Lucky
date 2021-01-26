namespace Models
{
    public class ListaOrdenItem
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public decimal PrecioUnidad { get; set; }
        public int Cantidad { get; set; }
    }
}
