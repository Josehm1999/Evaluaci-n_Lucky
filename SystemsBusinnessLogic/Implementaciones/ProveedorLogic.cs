using BusinnessLogic.Interfaces;
using Models;
using System.Collections.Generic;
using UnitOfWork;

namespace BusinnessLogic.Implementaciones
{
    public class ProveedorLogic : IProveedorLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProveedorLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public bool Delete(Proveedor proveedor) => _unitOfWork.Proveedor.Delete(proveedor);

        public Proveedor GetById(int id) => _unitOfWork.Proveedor.GetById(id);

        public int Insert(Proveedor proveedor) => _unitOfWork.Proveedor.Insert(proveedor);

        public IEnumerable<Proveedor> ListaPaginadaProveedor(int page, int rows, string busqueda) => _unitOfWork.Proveedor.ListaPaginadaProveedor(page, rows, busqueda);

        public bool Update(Proveedor proveedor) => _unitOfWork.Proveedor.Update(proveedor);
        public bool DeleteProveedor(int id) => _unitOfWork.Proveedor.DeleteProveedor(id);
        public bool InsertProveedor(Proveedor proveedor) => _unitOfWork.Proveedor.InsertProveedor(proveedor);

        public bool UpdateProveedor(Proveedor proveedor) => _unitOfWork.Proveedor.UpdateProveedor(proveedor);
    }
}
