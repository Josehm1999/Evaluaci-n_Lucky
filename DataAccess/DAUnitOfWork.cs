using Repositories;
using UnitOfWork;

namespace DataAccess
{
    public class DAUnitOfWork : IUnitOfWork
    {
        public DAUnitOfWork(string connectionString)
        {
            Cliente = new ClienteRepository(connectionString);
            Proveedor = new ProveedorRepository(connectionString);
            Orden = new OrdenRepository(connectionString);
        }
        public IClienteRepository Cliente { get; private set; }

        public IProveedorRepository Proveedor { get; private set; }

        public IOrdenRepository Orden { get; private set; }
    }
}
