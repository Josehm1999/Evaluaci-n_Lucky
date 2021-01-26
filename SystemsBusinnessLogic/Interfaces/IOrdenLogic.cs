using Models;
using System.Collections.Generic;

namespace BusinnessLogic.Interfaces
{
    public interface IOrdenLogic
    {
        IEnumerable<ListaOrden> GetOrdenPaginada(int page, int rows);
        ListaOrden GetOrdenById(int orderId);
        bool Delete(Orden order);
        Orden GetById(int orderId);
        string GetOrdenNumero(int orderId);
    }
}
