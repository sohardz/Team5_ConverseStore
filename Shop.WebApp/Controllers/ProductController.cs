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
			string ctSanphamApiURL = "https://localhost:7146/api/CTSanPhamAPI/";
			string danhmucApiURL = $"https://localhost:7146/api/DanhMucAPI/{id}";

			var ctSanphamApiResponse = await httpClient.GetAsync(ctSanphamApiURL);
			var danhmucApiURLResponse = await httpClient.GetAsync(danhmucApiURL);
			string ctSanphamApiData = await ctSanphamApiResponse.Content.ReadAsStringAsync();
			string danhmucApiData = await danhmucApiURLResponse.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(ctSanphamApiData);
			var result2 = JsonConvert.DeserializeObject<List<DanhMucVM>>(danhmucApiData);
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
