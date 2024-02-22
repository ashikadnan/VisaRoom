using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VisaRoom.Data.Services;

namespace VisaRoom.Data.ViewComponents
{
    public class CandidateList:ViewComponent
    {
        private readonly ICandidateService _service;

        public CandidateList(ICandidateService service)
        {
                _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _service.GetAllAsync(x => x.ApplyCountryObj, x => x.VisaTypeObj);

            return View(data);
        }

    }
}
