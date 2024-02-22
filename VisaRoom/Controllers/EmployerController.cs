using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using VisaRoom.Data.Services;
using VisaRoom.Data.ViewModels;
using VisaRoom.Models;

namespace VisaRoom.Controllers
{
    public class EmployerController : Controller
    {

        private readonly IEmployerService _service;
        private readonly ICandidateService _candidate;
        
        public EmployerController(IEmployerService service, ICandidateService candidate)
        {
            _service = service; 
            _candidate = candidate;
        }
        
        public async Task <IActionResult> Index()
        {
            var result = await _service.GetAllAsync();
            return View(result);
        }


        public IActionResult EmployerHome()
        {
            return View("EmployerHome");
        }


        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
   
        public async Task<IActionResult> Create(EmployerVM newEmployerVM)
        {
            if(newEmployerVM == null)
            {
                return View("Empty");
            }
            await _service.AddAsync(newEmployerVM);
            return RedirectToAction(nameof(Index)); 
        }


        public async Task <IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if(result == null)
            {
                return View("Empty");
            }

            var data = new EmployerVM()
            {               
                EmployerName = result.EmployerName, 
                EmployerPhone = result.EmployerPhone,   
                EmployerCity = result.EmployerCity,
                EmployerCountry = result.EmployerCountry,   
                EmployerCompany = result.EmployerCompany,
                EmployerImage = result.EmployerImage,
            };

            return View(data);
        }

        [HttpPost]
    
        public async Task<IActionResult> Edit(EmployerVM newEmployerVM)
        {
          if(!ModelState.IsValid)
            {
                return View("Empty");
            }

            var data = await _service.GetByIdAsync(newEmployerVM.Id);
            await _service.UpdateAsync(newEmployerVM,data);
            return RedirectToAction(nameof(Index));
        }

        public async Task <IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id); 
            return RedirectToAction(nameof(Index)); 
        }

        public async Task<IActionResult> EmployerRequest(int id)
        {
            string userNew = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _candidate.EmployerRequest(id, userNew);
            return RedirectToAction("EmployerHome");

        }

   
        public async Task<IActionResult> MyRequests()
        {
            var requestList = new List<Candidate>();
            var result = await _candidate.GetAll();
            string userNew = User.FindFirstValue(ClaimTypes.NameIdentifier);
            foreach (var item in result)
            {
                foreach(var items in item.Employer_RequestObj)
                {
                    if(userNew == items.UserId)
                    {
                        requestList.Add(item);
                    }
                }
            }
            return View(requestList);    
           

        }
    }
}
