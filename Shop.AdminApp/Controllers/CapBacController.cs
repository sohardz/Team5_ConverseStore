using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using System.Text;

namespace Shop.AdminApp.Controllers
{
    public class CapBacController : Controller
    {
        public CapBacController()
        {

        }

        public async Task<IActionResult> ShowAllCapBac()
        {
            string apiURL = "https://localhost:7146/api/CapBacAPI/get-all-capbac";

            var httpClient = new HttpClient();
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
            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7146/api/CapBacAPI";

            var json = JsonConvert.SerializeObject(capBacVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                RedirectToAction("ShowAllCapBac");
            }
            BadRequest();
            return View(capBacVM);
        }
    }
}
