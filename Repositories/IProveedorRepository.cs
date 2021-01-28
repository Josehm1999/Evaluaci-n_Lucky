using Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface IProveedorRepository: IRepository<Proveedor>
    {
        IEnumerable<Proveedor> ListaPaginadaProveedor(int page, int rows, string busqueda);
        bool UpdateProveedor(Proveedor proveedor);
        bool DeleteProveedor(int id);
        bool InsertProveedor(Proveedor proveedor);
    }
}
