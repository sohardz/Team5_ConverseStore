using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using System.Text;

namespace Shop.AdminApp.Controllers
{
	public class ChucVuController : Controller
	{
		public ChucVuController()
		{

		}
		public async Task<IActionResult> ShowAll()
		{
			var httpClient = new HttpClient();
			string apiURL = "https://localhost:7146/api/ChucVuAPI";


			var response = await httpClient.GetAsync(apiURL);
			string apiData = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<List<ChucVuVM>>(apiData);
			return View(result);
		}
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(ChucVuVM chucVuVM)
		{
			if (!ModelState.IsValid)
				return View(chucVuVM);

			var httpClient = new HttpClient();

			string apiURL = "https://localhost:7146/api/ChucVuAPI";

			var json = JsonConvert.SerializeObject(chucVuVM);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await httpClient.PostAsync(apiURL, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAll");
			}
			ModelState.AddModelError("", "Create Sai roi");

			return View(chucVuVM);
		}
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/ChucVuAPI/chucvu/{id}";

			var response = await httpClient.GetAsync(apiURL);

			string apiData = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<ChucVuVM>(apiData);
			return View(result);
		}

		public async Task<IActionResult> Edit(ChucVuVM chucVuVM)
		{
			if (!ModelState.IsValid) return View(chucVuVM);

			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/ChucVuAPI/{chucVuVM.Id}";

			var json = JsonConvert.SerializeObject(chucVuVM);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			//var content = new StringContent(JsonConvert.SerializeObject(capBacVM, Encoding.UTF8, "application/json");

			var response = await httpClient.PutAsync(apiURL, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAll");
			}
			ModelState.AddModelError("", "Edit sai roi be oi");

			return View(chucVuVM);
		}
		public async Task<IActionResult> Delete(Guid id)
		{
			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/ChucVuAPI/{id}";

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
