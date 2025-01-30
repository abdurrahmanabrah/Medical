﻿//using Hospital.Model;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Consultation consultation)
        {
            if (!ModelState.IsValid)
            {
                return View(consultation);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync("https://localhost:7050/api/Consultations", consultation);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        // Handle API error
                        ViewBag.ErrorMessage = "Failed to create a new consultation.";
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

            return View(consultation);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                Consultation consultation = new Consultation();
                

                using (var client = new HttpClient())
                {

                    var response = await client.GetAsync("https://localhost:7050/api/Consultations/"+id);
                    if (response.IsSuccessStatusCode)
                    {
                        // return RedirectToAction(nameof(Index));
                        consultation = response.Content.ReadAsAsync<Consultation>().Result;
                        return View(consultation);
                    }
                    else
                    {
                        // Handle API error
                        //ViewBag.ErrorMessage = "Failed to create a new degree.";
                        ViewBag.ErrorMessage = "Failed to fetch the degree Consultations.";
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
        public async Task<IActionResult> Edit(Consultation consultation)
        {
            if (!ModelState.IsValid)
            {
                return View(consultation);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PutAsJsonAsync($"https://localhost:7050/api/Consultations", consultation);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        // Handle API error
                        //ViewBag.ErrorMessage = "Failed to create a new degree.";
                        ViewBag.ErrorMessage = "Failed to fetch the degree Consultations.";
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
            }

            return View(consultation);
        }

    }
}
