using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VisaRoom.Data;
using VisaRoom.Data.Services;
using VisaRoom.Models;

namespace VisaRoom.Controllers
{
    public class ApplyCountryController : Controller
    {

        private readonly IApplyCountryService _service;

        public ApplyCountryController(IApplyCountryService service)
        {
            _service = service;
        }
        public async Task <IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind("ApplyCountryName")] ApplyCountry applyCountry)
        {
            if(!ModelState.IsValid)
            {
                return View(applyCountry);
            }
            
            await _service.AddAsync(applyCountry);
            return RedirectToAction("Index");
        }

        public async Task <IActionResult> Edit(int id)
        {
            var data = await _service.GetById(id);
            if(data == null)
            {
                return View("Empty");
            }
            return View(data);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("ApplyCountryName")] ApplyCountry newApplyCountry)
        {
            if (!ModelState.IsValid)
            {
                return View(newApplyCountry);
            }

            await _service.UpdateAsync(id, newApplyCountry);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");   
        }
    }
}

