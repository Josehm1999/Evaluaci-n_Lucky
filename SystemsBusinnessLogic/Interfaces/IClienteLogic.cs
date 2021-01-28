using Models;
using System.Collections.Generic;

namespace BusinnessLogic.Interfaces
{
    public interface IClienteLogic
    {
        Cliente GetById(int Id);
        IEnumerable<ListaCliente> ClientesPaginados(int page, int rows);
        IEnumerable<Cliente> GetList();
        int Insert(Cliente cliente);
        bool Update(Cliente cliente);
        bool Delete(int Id);
    }
}
