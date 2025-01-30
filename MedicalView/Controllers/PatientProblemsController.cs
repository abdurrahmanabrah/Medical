
using MedicalView.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalView.Controllers
{
    public class PatientProblemsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<PatientProblem> patientproblem = new List<PatientProblem>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7050/api/PatientProblems");
                if (response.IsSuccessStatusCode)
                {
                    patientproblem = response.Content.ReadAsAsync<List<PatientProblem>>().Result;
                    return View(patientproblem);
                }
            }
            return View(Enumerable.Empty<PatientProblem>());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.ProblemId = new SelectList(await GetProblem(), "Id", "Name");
            ViewBag.PatientId = new SelectList(await GetPatient(), "Id", "Age");
            return View();
        }
        public async Task<List<Problem>> GetProblem(){ 
            List<Problem> problem = new List<Problem>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7050/api/Problems");
                if (response.IsSuccessStatusCode)
                {
                    problem = response.Content.ReadAsAsync<List<Problem>>().Result;
                }

            }

            return problem;
        }
        public async Task<List<Patient>> GetPatient()
        {
            List<Patient> patient = new List<Patient>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7050/api/Patients");
                if (response.IsSuccessStatusCode)
                {
                    patient = response.Content.ReadAsAsync<List<Patient>>().Result;
                }
            }

            return patient;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientProblem patientProblem)
        {
            if (!ModelState.IsValid)
            {
                return View(patientProblem);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync("https://localhost:7050/api/PatientProblems", patientProblem);
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

            return View(patientProblem);
        }

    }
}
