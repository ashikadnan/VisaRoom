using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VisaRoom.Data.Services;
using VisaRoom.Data.ViewModels;

namespace VisaRoom.Data.ViewComponents
{
    public class EmployerDash:ViewComponent
    {
        private readonly IEmployerService _service;
        public EmployerDash(IEmployerService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var employer = await _service.GetAllAsync();
            return View(employer);
        }

    }
}
