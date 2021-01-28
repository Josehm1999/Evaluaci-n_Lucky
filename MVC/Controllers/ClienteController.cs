using BusinnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Controllers
{

    public class ClienteController : Controller
    {

        private readonly IClienteLogic _logic;
        [BindProperty]
        public ClienteMVC ClienteMVC { get; set;}
        public ClienteController(IClienteLogic logic)
        {
            _logic = logic;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        private Task<List<Cliente>> GetListAsync()
        {
            List<Cliente> Lista = new List<Cliente>();
            foreach (Cliente cliente in _logic.ClientesPaginados(1, 10))
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


        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Cliente cliente= new Cliente();
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
        public IActionResult Upsert(ClienteMVC cliente)
        {
           /* if (ModelState.IsValid)
            {
                if (cliente.Id == 0)
                {
                    _logic.Insert(cliente);
                }
                else
                {
                    _logic.Update(cliente);
                }
                return RedirectToAction("Index");
            }*/
            return View(cliente);
        }
        private Task<bool> DeleteAsync(int id)
        {
            return Task.Run(() => _logic.Delete(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            
            if (id < 0)
            {
                return Json(new { success = false, message = "Error al eliminar " });
            }
            await DeleteAsync(id);
            return Json(new { success = true, message = "Eliminado exitosamente! " });
        }
    }
}
