using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VisaRoom.Data;
using VisaRoom.Data.Services;
using VisaRoom.Models;

namespace VisaRoom.Controllers
{
    public class VisaTypeController : Controller
    {
        private readonly IVisaTypeServices _service;

        public VisaTypeController(IVisaTypeServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("VisaTypeName")]VisaType visaType) 
        {
            if (!ModelState.IsValid)
            {
                return View(visaType);
            }

            await _service.AddAsync(visaType);
            return RedirectToAction("Index");   
        }


       public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetById(id);
            if(data == null)
            {
                return View("Empty");
            }
            return View(data);  
        }
        
        public async Task <IActionResult> Edit(int id)
        {
            var data = await _service.GetById(id);
            if (data == null)
            {
                return View("Empty");
            }
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("VisaTypeName")] VisaType visaType, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(visaType);
            }

            await _service.UpdateAsync(id, visaType);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
