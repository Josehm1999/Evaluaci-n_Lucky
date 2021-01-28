using BusinnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Controllers
{

    public class ClienteController : Controller
    {


        private readonly IClienteLogic _logic;

        [BindProperty]
        public Cliente cliente { get; set; }
        public ClienteController(IClienteLogic logic)
        {
            _logic = logic;

        }

        public IActionResult Index()
        {
            return View();
        }

      
        private Task<List<Cliente>> GetListAsync()
        {
            List<Cliente> Lista = new List<Cliente>();
            foreach (Cliente cliente in _logic.GetList())  //ClientesPaginados(1, 10))
            {
                Lista.Add(cliente);
            };
            return Task.Run(() => Lista);
        }



        [HttpGet]
        public async Task<ActionResult> ClientesPaginados()
        {
            return Json(new { data = await GetListAsync() });
        }

        public IActionResult Upsert(int? id)
        {
            cliente = new Cliente();
            if (id == null)
            {
                return View(cliente);
            }
            //update
            cliente =  _logic.GetById(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (cliente.Id == 0)
                {
                    _logic.InsertCliente(cliente);
                }
                else
                {
                    _logic.UpdateCliente(cliente);
                }
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        private Task<bool> DeleteAsync(int id)
        {
            bool valor = _logic.DeleteCliente(id);
            return Task.Run(() => valor);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool valor = await DeleteAsync(id);
            if (valor)
            {
                return Json(new { success = true, message = "Eliminado exitosamente! " });
                
            }
            return Json(new { success = false, message = "Error al eliminar " });
        }

    }
}
