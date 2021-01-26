using BusinnessLogic.Interfaces;
using Models;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork;

namespace BusinnessLogic.Implementaciones
{
    public class OrdenLogic : IOrdenLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdenLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public bool Delete(Orden orden)=>  _unitOfWork.Orden.Delete(orden);

        public Orden GetById(int ordenId) =>  _unitOfWork.Orden.GetById(ordenId);

        public ListaOrden GetOrdenById(int orderId) => _unitOfWork.Orden.GetOrdenById(orderId);

        public string GetOrdenNumero(int orderId)
        {
            var list = _unitOfWork.Orden.GetList();
            var registro = list.First(x => x.Id == orderId);
            return registro.OrdenNumero;
        }
        public IEnumerable<ListaOrden> GetOrdenPaginada(int page, int rows) => _unitOfWork.Orden.GetOrdenPaginada(page, rows);
    }
}
