using Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {

        bool DeleteCliente(int id);
        IEnumerable<ListaCliente> ListaPaginadaCliente(int page, int rows);

        bool UpdateCliente(Cliente cliente);

        bool InsertCliente(Cliente cliente);
    }
}
