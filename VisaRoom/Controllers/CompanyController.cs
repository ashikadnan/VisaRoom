using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VisaRoom.Data;
using VisaRoom.Data.Services;
using VisaRoom.Models;

namespace VisaRoom.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _service;
        public CompanyController(ICompanyService service)
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
        public async Task <IActionResult> Create ([Bind("CompanyName,CompanyLocation")] Company company)
        {
            /*if (!ModelState.IsValid)
            {
                return View(company);
            }*/

            await _service.AddAsync(company);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetById(id);
            if (details == null)
            {
                return View("Empty");
            }
            return View(details);   
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetById(id);
            if(data == null)
            {
                return View("Empty");
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("CompanyName,CompanyLocation")] Company newCompany)
        {
            /*if (!ModelState.IsValid)
            {
                return View(newCompany);
            }*/
            await _service.UpdateAsync(id, newCompany);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
