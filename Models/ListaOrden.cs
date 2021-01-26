using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class ListaOrden
    {
        public int OrdenId { get; set; }
        public DateTime OrdenFecha { get; set; }
        public int OrdenNumero { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public decimal CantidadTotal { get; set; }
        public int TotalRecords { get; set; }
        public List<ListaOrdenItem> DetallesOrden { get; set; }
        public void SetDetails(List<ListaOrdenItem> details)
        {
            DetallesOrden = details.Where(x => x.OrdenId == OrdenId).ToList();
        }
    }
}
