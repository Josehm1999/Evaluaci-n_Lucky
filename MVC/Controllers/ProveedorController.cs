using BusinnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Controllers
{

    public class ProveedorController : Controller
    {

        private readonly IProveedorLogic _logic;

        [BindProperty]
        public Proveedor Proveedor { get; set; }
        public ProveedorController(IProveedorLogic logic)
        {
            _logic = logic;

        }

        public IActionResult Index()
        {
            return View();
        }


        private Task<List<Proveedor>> GetListAsync()
        {
            List<Proveedor> Lista = new List<Proveedor>();
            foreach (Proveedor proveedor in _logic.ListaPaginadaProveedor(1,10, ""))  //ClientesPaginados(1, 10))
            {
                Lista.Add(proveedor);
            };
            return Task.Run(() => Lista);
        }



        [HttpGet]
        public async Task<ActionResult> ProveedoresPaginados()
        {
            return Json(new { data = await GetListAsync() });
        }

        public IActionResult Upsert(int? id)
        {
            Proveedor = new Proveedor();
            if (id == null)
            {
                return View(Proveedor);
            }
            //update
            Proveedor = _logic.GetById(id.Value);
            if (Proveedor == null)
            {
                return NotFound();
            }
            return View(Proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Proveedor.Id == 0)
                {
                    _logic.InsertProveedor(Proveedor);
                }
                else
                {
                    _logic.UpdateProveedor(Proveedor);
                }
                return RedirectToAction("Index");
            }
            return View(Proveedor);
        }

        private Task<bool> DeleteAsync(int id)
        {
            bool valor = _logic.DeleteProveedor(id);
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
