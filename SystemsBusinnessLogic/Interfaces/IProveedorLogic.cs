using Models;
using System.Collections.Generic;

namespace BusinnessLogic.Interfaces
{
    public interface IProveedorLogic
    {
        Proveedor GetById(int id);
        IEnumerable<Proveedor> ListaPaginadaProveedor(int page, int rows, string busqueda);
        int Insert(Proveedor proveedor);
        bool Update(Proveedor proveedor);
        bool Delete(Proveedor proveedor);
    }
}
