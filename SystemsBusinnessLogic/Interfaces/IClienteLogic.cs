using Models;
using System.Collections.Generic;

namespace BusinnessLogic.Interfaces
{
    public interface IClienteLogic
    {
        Cliente GetById(int Id);
        IEnumerable<ListaCliente> ClientesPaginados(int page, int rows);
        IEnumerable<Cliente> GetList();
        bool DeleteCliente(int id);
        bool InsertCliente(Cliente cliente);
        bool UpdateCliente(Cliente cliente);
    }
}
