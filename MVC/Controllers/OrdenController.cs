using BusinnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class OrdenController : Controller
    {
        private readonly IOrdenLogic _logic;
        
        public OrdenController(IOrdenLogic logic)
        {
            _logic = logic;

        }
        public IActionResult Index()
        {
            return View();
        }


        private Task<List<ListaOrden>> GetListAsync()
        {
            List<ListaOrden> Lista = new List<ListaOrden>();
            foreach (var orden in _logic.GetOrdenPaginada(1, 10))
            {
                Lista.Add(orden);
            };
            return Task.Run(() => Lista);
        }


        [HttpGet]
        public async Task<ActionResult> OrdenesPaginados()
        {
            return Json(new { data = await GetListAsync() });
        }
    }
}
