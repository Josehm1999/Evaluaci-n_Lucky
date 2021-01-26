using Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface IProveedorRepository: IRepository<Proveedor>
    {
        IEnumerable<Proveedor> ListaPaginadaProveedor(int page, int rows, string busqueda);
    }
}
