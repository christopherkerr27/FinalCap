using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FinalCap.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService _service;
        public CarsController(ICarsService service)
        {
            _service = service;
        }
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAll();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Car car)
        {
            if (ModelState.IsValid)
            {
                await _services.Create(car);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
      
    }
}
