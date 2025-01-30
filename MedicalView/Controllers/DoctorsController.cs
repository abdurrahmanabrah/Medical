using MedicalView.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalView.Controllers
{
    public class DoctorsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Doctor> doctor = new List<Doctor>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7050/api/Doctors");
                if (response.IsSuccessStatusCode)
                {
                    doctor = response.Content.ReadAsAsync<List<Doctor>>().Result;
                    return View(doctor);
                }

            }

            return View(Enumerable.Empty<Doctor>());
        }


        [HttpGet]
        public async  Task<IActionResult> Create()
        {
            ViewBag.DegreeId = new SelectList(await GetDegree(), "Id", "Name");
            ViewBag.InstituteId = new SelectList(await GetInstitute(), "Id", "Name");
            ViewBag.ConsultationId = new SelectList(await GetConsultation(), "Id", "Name");
            ViewBag.SpecialInterestId = new SelectList(await GetSpecialInterest(), "Id", "Name");
            return View();
        }
        public async Task<List<Degree>> GetDegree()
        {
            List<Degree> degree = new List<Degree>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7050/api/Degrees");
                if (response.IsSuccessStatusCode)
                {
                    degree = response.Content.ReadAsAsync<List<Degree>>().Result;
                }

            }

           return  degree;
        }
        public async Task<List<Consultation>> GetConsultation()
        {
            List<Consultation> consultations = new List<Consultation>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7050/api/Consultations");
                if (response.IsSuccessStatusCode)
                {
                    consultations = response.Content.ReadAsAsync<List<Consultation>>().Result;
                }

            }

            return consultations;
        }
        public async Task<List<SpecialInterest>> GetSpecialInterest()
        {
            List<SpecialInterest> specialInterests = new List<SpecialInterest>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7050/api/SpecialInterests");
                if (response.IsSuccessStatusCode)
                {
                    specialInterests = response.Content.ReadAsAsync<List<SpecialInterest>>().Result;
                }

            }

            return specialInterests;
        }


        public async Task<List<Institute>> GetInstitute()
        {
            List<Institute> institute = new List<Institute>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7050/api/Institutes");
                if (response.IsSuccessStatusCode)
                {
                    institute = response.Content.ReadAsAsync<List<Institute>>().Result;
                }

            }

            return institute;
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync("https://localhost:7050/api/Doctors", doctor);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        // Handle API error
                        ViewBag.ErrorMessage = "Failed to create a new degree.";
                    }

                }
                //if (response.IsSuccessStatusCode)
                //{
                //    return RedirectToAction(nameof(Index));
                //}

            }
            catch (Exception ex)
            {
                // Log the exception
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
            }

            return View(doctor);
        }



    }
}
