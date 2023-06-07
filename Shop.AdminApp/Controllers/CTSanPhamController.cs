using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using System.Text;

namespace Shop.AdminApp.Controllers
{
    public class CTSanPhamController : Controller
    {
        public CTSanPhamController()
        {

        }

        public async Task<IActionResult> ShowAll()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7146/api/CTSanPhamAPI/";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CTSanPhamVM cTSanPhamVM)
        {
            if (!ModelState.IsValid)
                return View(cTSanPhamVM);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7146/api/CTSanPhamAPI/";

            var json = JsonConvert.SerializeObject(cTSanPhamVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "Sai roi");

            return View(cTSanPhamVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7146/api/CTSanPhamAPI/{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CTSanPhamVM>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(CTSanPhamVM cTSanPhamVM)
        {
            if (!ModelState.IsValid) return View(cTSanPhamVM);

            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7146/api/CTSanPhamAPI/";

            var json = JsonConvert.SerializeObject(cTSanPhamVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai roi be oi");

            return View(cTSanPhamVM);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7146/api/CTSanPhamAPI/{id}";

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
