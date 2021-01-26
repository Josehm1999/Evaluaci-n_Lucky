using Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface IOrdenRepository: IRepository<Orden>
    {
        IEnumerable<ListaOrden> GetOrdenPaginada(int page, int rows);
        ListaOrden GetOrdenById(int ordenId);
    }
}
