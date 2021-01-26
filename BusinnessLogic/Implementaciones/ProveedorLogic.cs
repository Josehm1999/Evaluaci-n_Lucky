using BusinnessLogic.Interfaces;
using Models;
using System.Collections.Generic;
using UnitOfWork;
using DataAccess;

namespace BusinnessLogic.Implementaciones
{
    public class ProveedorLogic : IProveedorLogic
    {

        public ProveedorLogic();
        public bool Delete(Proveedor proveedor) => Repository<Proveedor>;

        public Proveedor GetById(int id) => _unitOfWork.Proveedor.GetById(id);

        public int Insert(Proveedor proveedor) => _unitOfWork.Proveedor.Insert(proveedor);

        public IEnumerable<Proveedor> ListaPaginadaProveedor(int page, int rows, string busqueda) => _unitOfWork.Proveedor.ListaPaginadaProveedor(page, rows, busqueda);

        public bool Update(Proveedor proveedor) => _unitOfWork.Proveedor.Update(proveedor);
    }
}
