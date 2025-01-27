
using MedicalView.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace MedicalView.Controllers
{
    public class DegreesController : Controller
    {
        
        public async Task< IActionResult> Index()
        {
            List<Degree> degree = new List<Degree>();
            using (var client = new HttpClient()) {
              var response= await client.GetAsync("https://localhost:7050/api/Degrees");
             if(response.IsSuccessStatusCode)
                {
                degree= response.Content.ReadAsAsync<List< Degree>>().Result;
                    return View(degree);
                }
            
            }

            return View(Enumerable.Empty<Degree>());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Degree degree)
        {
            if (!ModelState.IsValid)
            {
                return View(degree);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync("https://localhost:7050/api/Degrees", degree);
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

            return View(degree);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
             Degree degree =new Degree();
                //degree.Fi(Id == id);

                using (var client = new HttpClient())
                {

                    var response = await client.GetAsync("https://localhost:7050/api/Degrees/"+id);
                    if (response.IsSuccessStatusCode)
                    {
                       // return RedirectToAction(nameof(Index));
                        degree = response.Content.ReadAsAsync<Degree>().Result;
                        return View(degree);
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
        public async Task<IActionResult> Edit(Degree degree)
        {
            if (!ModelState.IsValid)
            {
                return View(degree);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PutAsJsonAsync($"https://localhost:7050/api/Degrees", degree);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        // Handle API error
                        //ViewBag.ErrorMessage = "Failed to create a new degree.";
                        ViewBag.ErrorMessage = "Failed to fetch the degree details.";
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
            }

            return View(degree);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"https://localhost:7050/api/Degrees/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var degree = await response.Content.ReadFromJsonAsync<Degree>();
                        return View(degree);
                    }
                }

                ViewBag.ErrorMessage = "Failed to fetch the degree details.";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.DeleteAsync($"https://localhost:7050/api/Degrees/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                ViewBag.ErrorMessage = "Failed to delete the degree.";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
