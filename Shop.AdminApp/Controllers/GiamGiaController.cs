﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using System.Text;

namespace Shop.AdminApp.Controllers
{
    public class GiamGiaController : Controller
    {
        public GiamGiaController()
        {
            
        }
        public async Task<IActionResult> ShowAll()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7146/api/GiamGiaAPI/get-all-giamgia";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<GiamGiaVM>>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GiamGiaVM GiamGiaVM)
        {
            if (!ModelState.IsValid)
                return View(GiamGiaVM);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7146/api/GiamGiaAPI/create-giamgia";

            var json = JsonConvert.SerializeObject(GiamGiaVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "Sai roi");

            return View(GiamGiaVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7146/api/GiamGiaAPI/get-giamgia/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GiamGiaVM>(apiData);
            return View(result);
        }
           
        public async Task<IActionResult> Edit(GiamGiaVM GiamGiaVM)
        {
           
            if (!ModelState.IsValid) return View(GiamGiaVM);

            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7146/api/GiamGiaAPI/update-giamgia";

            var json = JsonConvert.SerializeObject(GiamGiaVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //var content = new StringContent(JsonConvert.SerializeObject(GiamGiaVM, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai roi be oi");

            return View(GiamGiaVM);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7146/api/GiamGiaAPI/delete-giamgia/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai tiep roi be oi");
            return BadRequest();
        }
    }
}
