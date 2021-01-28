using BusinnessLogic.Interfaces;
using Models;
using System.Collections.Generic;
using DataAccess;
using UnitOfWork;

namespace BusinnessLogic.Implementaciones
{
    public class ClienteLogic: IClienteLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClienteLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool Delete(int Id) => _unitOfWork.Cliente.Delete(Id);

        public Cliente GetById(int Id) => _unitOfWork.Cliente.GetById(Id);

        public IEnumerable<Cliente> GetList() => _unitOfWork.Cliente.GetList();

        public int Insert(Cliente cliente) => _unitOfWork.Cliente.Insert(cliente);

        public bool Update(Cliente cliente) => _unitOfWork.Cliente.Update(cliente);

        IEnumerable<ListaCliente> IClienteLogic.ClientesPaginados(int page, int rows) => _unitOfWork.Cliente.ListaPaginadaCliente(page, rows);
    }
}
