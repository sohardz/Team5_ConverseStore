using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;

namespace Shop.AdminApp.Controllers
{
    public class HoaDonController : Controller
    {
        public HoaDonController()
        {

        }

        public async Task<IActionResult> ShowAll()
        {
            var httpClient = new HttpClient();
            var apiURL = "https://localhost:7146/api/HoaDonAPI";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<HoaDonVM>>(apiData);

            return View(result);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var httpClient = new HttpClient();
            var apiURL = $"https://localhost:7146/api/CTHoaDonAPI/get-all/{id}";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CTHoaDonVM>>(apiData);

            return View(result);
        }
    }
}
