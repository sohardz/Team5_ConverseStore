﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using System.Text;

namespace Shop.AdminApp.Controllers
{
    public class MauSacController : Controller
    {
        public MauSacController()
        {
            
        }
        public async Task<IActionResult> ShowAll()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7146/api/MauSacAPI/";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<MauSacVM>>(apiData);
            return View(result);
        }


        // GET: DanhMucController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MauSacVM collection)
        {
            if (!ModelState.IsValid)
                return View(collection);
            var httpClient = new HttpClient();

            string apiURL = $"https://localhost:7146/api/MauSacAPI/";

            var json = JsonConvert.SerializeObject(collection);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "Sai roi");

            return View(collection);
        }

        // GET: DanhMucController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7146/api/MauSacAPI/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MauSacVM>(apiData);
            return View(result);
        }

        // POST: DanhMucController/Edit/5
        public async Task<IActionResult> Edit(MauSacVM collection)
        {
            if (!ModelState.IsValid) return View(collection);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7146/api/MauSacAPI/{collection.Id}";

            var json = JsonConvert.SerializeObject(collection);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai roi be oi");

            return View(collection);
        }

        // POST: DanhMucController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7146/api/MauSacAPI/{id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "hong dung r");
            return BadRequest();
        }
    }
}