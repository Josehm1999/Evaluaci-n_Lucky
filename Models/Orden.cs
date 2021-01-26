using System;

namespace Models
{
    public class Orden
    {
        public int Id { get; set; }
        public DateTime OrdenFecha { get; set; }
        public string OrdenNumero { get; set; }
        public int ClienteId { get; set; }
        public decimal CantidadTotal { get; set; }
    }
}
