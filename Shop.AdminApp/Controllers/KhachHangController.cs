using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using System.Text;

namespace Shop.AdminApp.Controllers
{
    public class KhachHangController : Controller
    {
        public async Task<IActionResult> ShowAll()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7146/api/KhachHangAPI";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<KhachHangVM>>(apiData);
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(KhachHangVM khachhangVM)
        {
            if (!ModelState.IsValid)
                return View(khachhangVM);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7146/api/KhachHangAPI";

            var json = JsonConvert.SerializeObject(khachhangVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "Sai roi");

            return View(khachhangVM);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7146/api/KhachHangAPI/khachhang/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<KhachHangVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(KhachHangVM khachHangVM)
        {
            if (!ModelState.IsValid) return View(khachHangVM);

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7146/api/KhachHangAPI/{khachHangVM.Id}";

            var json = JsonConvert.SerializeObject(khachHangVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //var content = new StringContent(JsonConvert.SerializeObject(capBacVM, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai roi be oi");

            return View(khachHangVM);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7146/api/KhachHangAPI/{id}";

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
