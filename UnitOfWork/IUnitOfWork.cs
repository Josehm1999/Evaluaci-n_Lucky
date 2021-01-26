using Repositories;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {
        IClienteRepository Cliente { get;  }
        IProveedorRepository Proveedor { get; }
        IOrdenRepository Orden{ get; }
    }
}
