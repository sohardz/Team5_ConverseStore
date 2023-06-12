using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using System.Text;

namespace Shop.AdminApp.Controllers
{
	public class NhanVienController : Controller
	{
		public NhanVienController()
		{

		}
		public async Task<IActionResult> ShowAll()
		{
			var httpClient = new HttpClient();
			string apiURL = "https://localhost:7146/api/NhanVienAPI";


			var response = await httpClient.GetAsync(apiURL);
			string apiData = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<List<NhanVienVM>>(apiData);
			return View(result);
		}
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(NhanVienVM nhanVienVM)
		{
			if (!ModelState.IsValid)
				return View(nhanVienVM);

			var httpClient = new HttpClient();

			string apiURL = "https://localhost:7146/api/NhanVienAPI";

			var json = JsonConvert.SerializeObject(nhanVienVM);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await httpClient.PostAsync(apiURL, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAll");
			}
			ModelState.AddModelError("", "Create Sai roi");

			return View(nhanVienVM);
		}
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/NhanVienAPI/nhanvien/{id}";

			var response = await httpClient.GetAsync(apiURL);

			string apiData = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<NhanVienVM>(apiData);
			return View(result);
		}

		public async Task<IActionResult> Edit(NhanVienVM nhanVienVM)
		{
			if (!ModelState.IsValid) return View(ModelState);

			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/NhanVienAPI/{nhanVienVM.Id}";

			var json = JsonConvert.SerializeObject(nhanVienVM);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await httpClient.PutAsync(apiURL, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAll");
			}
			ModelState.AddModelError("", "Edit sai roi be oi");

			return View(nhanVienVM);
		}
		public async Task<IActionResult> Delete(Guid id)
		{
			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/NhanVienAPI/{id}";

			var response = await httpClient.DeleteAsync(apiURL);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAll");
			}
			ModelState.AddModelError("", "Delete sai tiep roi be oi");
			return BadRequest();
		}

	}
}
