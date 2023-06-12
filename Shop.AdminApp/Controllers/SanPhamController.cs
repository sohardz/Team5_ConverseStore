using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using System.Text;

namespace Shop.AdminApp.Controllers
{
	public class SanPhamController : Controller
	{
		public SanPhamController()
		{

		}

		public async Task<IActionResult> ShowAll()
		{
			var httpClient = new HttpClient();
			string apiURL = "https://localhost:7146/api/SanPhamAPI/";
			var response = await httpClient.GetAsync(apiURL);
			string apiData = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<List<SanPhamVM>>(apiData);
			return View(result);
		}

		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(SanPhamVM sanPhamVM)
		{
			if (!ModelState.IsValid)
				return View(sanPhamVM);

			var httpClient = new HttpClient();
			string apiURL = "https://localhost:7146/api/SanPhamAPI/";
			var json = JsonConvert.SerializeObject(sanPhamVM);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await httpClient.PostAsync(apiURL, content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAll");
			}
			ModelState.AddModelError("", "Sai roi");

			return View(sanPhamVM);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/SanPhamAPI/sanpham/{id}";

			var response = await httpClient.GetAsync(apiURL);

			string apiData = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<SanPhamVM>(apiData);
			return View(result);
		}

		public async Task<IActionResult> Edit(SanPhamVM sanPhamVM)
		{
			if (!ModelState.IsValid) return View(sanPhamVM);

			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/SanPhamAPI/{sanPhamVM.Id}";

			var json = JsonConvert.SerializeObject(sanPhamVM);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await httpClient.PutAsync(apiURL, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAll");
			}
			ModelState.AddModelError("", "sai roi be oi");

			return View(sanPhamVM);
		}

		public async Task<IActionResult> Delete(Guid id)
		{
			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/SanPhamAPI/{id}";

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
