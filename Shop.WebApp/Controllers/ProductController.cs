using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using Shop.WebApp.Models;

namespace Shop.WebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var httpClient = new HttpClient();

            string apiURL = $"https://localhost:7146/api/CTSanPhamAPI/ctsanpham/{id}";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CTSanPhamVM>(apiData);
            ViewBag.ImagePath = result.Anhs;
            return View(new ProductDetailVM()
            {
                Product = result
            });

        }
    }
        
}
