using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Shop.AdminApp.Controllers
{
    public class CapBacController : Controller
    {
        public CapBacController()
        {

        }

        public async Task<IActionResult> ShowAll()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7146/api/CapBacAPI/get-all-capbac";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CapBacVM>>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CapBacVM capBacVM)
        {
            if (!ModelState.IsValid)
                return View(capBacVM);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7146/api/CapBacAPI";

            var json = JsonConvert.SerializeObject(capBacVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
               return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("","Sai roi");

            return View(capBacVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7146/api/CapBacAPI/get-capbac/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CapBacVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(CapBacVM capBacVM)
        {
            if(!ModelState.IsValid) return View(capBacVM);

            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7146/api/CapBacAPI/update-capbac";

            var json = JsonConvert.SerializeObject(capBacVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //var content = new StringContent(JsonConvert.SerializeObject(capBacVM, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai roi be oi");

            return View(capBacVM);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7146/api/CapBacAPI/delete-capbac/{id}";

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
