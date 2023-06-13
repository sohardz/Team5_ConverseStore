using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using Shop.WebApp.Models;
using System.Text.RegularExpressions;

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
		public async Task<IActionResult> Category(Guid id)
		{

			var httpClient = new HttpClient();
			string apiURL = "https://localhost:7146/api/CTSanPhamAPI/";
			string apiURL2 = $"https://localhost:7146/api/DanhMucAPI/{id}";

			var response = await httpClient.GetAsync(apiURL);
			var response2 = await httpClient.GetAsync(apiURL2);
			string apiData = await response.Content.ReadAsStringAsync();
			string apiData2 = await response2.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(apiData);
			var result2 = JsonConvert.DeserializeObject<List<DanhMucVM>>(apiData2);
			var products = new CTSanPhamVM{
                IdDanhMuc = id
            };
			return View(new ProductDetailVM()
			{
				//Category = await 
				Product = products
			});

		}
	}
        
}
