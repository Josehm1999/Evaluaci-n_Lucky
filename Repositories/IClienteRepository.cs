using Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IEnumerable<ListaCliente> ListaPaginadaCliente(int page, int rows);
    }
}
