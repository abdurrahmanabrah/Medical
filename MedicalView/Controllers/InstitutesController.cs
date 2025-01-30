using MedicalView.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalView.Controllers
{
    public class InstitutesController : Controller
    {
        
            public async Task<IActionResult> Index()
        {
            List<Institute> institutes = new List<Institute>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7050/api/Institutes");
                if (response.IsSuccessStatusCode)
                {
                    institutes = response.Content.ReadAsAsync<List<Institute>>().Result;
                    return View(institutes);
                }

            }

            return View(Enumerable.Empty<Institute>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Institute institute)
        {
            if (!ModelState.IsValid)
            {
                return View(institute);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync("https://localhost:7050/api/Institutes", institute);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        // Handle API error
                        ViewBag.ErrorMessage = "Failed to create a new Institute.";
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

            return View(institute);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                Institute institute = new Institute();
                //degree.Fi(Id == id);

                using (var client = new HttpClient())
                {

                    var response = await client.GetAsync("https://localhost:7050/api/Institutes/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        // return RedirectToAction(nameof(Index));
                        institute = response.Content.ReadAsAsync<Institute>().Result;
                        return View(institute);
                    }
                    else
                    {
                        // Handle API error
                        //ViewBag.ErrorMessage = "Failed to create a new degree.";
                        ViewBag.ErrorMessage = "Failed to fetch the degree details.";
                    }

                }
                //ViewBag.ErrorMessage = "Failed to fetch the degree details.";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Institute institute)
        {
            if (!ModelState.IsValid)
            {
                return View(institute);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PutAsJsonAsync($"https://localhost:7050/api/Institutes", institute);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        // Handle API error
                        //ViewBag.ErrorMessage = "Failed to create a new degree.";
                        ViewBag.ErrorMessage = "Failed to fetch the degree Institute.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
            }
            return View(institute);
        }


    }
}
