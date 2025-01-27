//using Hospital.Model;
using MedicalView.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalView.Controllers
{
    public class ConsultationsController : Controller
    {
        public async Task <IActionResult> Index()
        {
            List<Consultation> oconsultation = new List<Consultation>();
            using (var client = new HttpClient())
            {
                var res = await client.GetAsync("https://localhost:7050/api/Consultations");
                if (res.IsSuccessStatusCode)
                {
                    oconsultation = res.Content.ReadAsAsync<List<Consultation>>().Result;
                    return View(oconsultation);
                }
            }
            return View(Enumerable.Empty<Consultation>());
        }
    }
}
