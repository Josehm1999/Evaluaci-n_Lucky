using Models;
using System.Collections.Generic;

namespace BusinnessLogic.Interfaces
{
    public interface IProveedorLogic
    {
        Proveedor GetById(int id);
        IEnumerable<Proveedor> ListaPaginadaProveedor(int page, int rows, string busqueda);
        bool DeleteProveedor(int id);
        bool InsertProveedor(Proveedor proveedor);
        bool UpdateProveedor(Proveedor proveedor);

    }
}
