using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using System.Text;


namespace Shop.AdminApp.Controllers
{
	public class KichCoController : Controller
	{
		public KichCoController()
		{

		}
		public async Task<IActionResult> ShowAll()
		{
			var httpClient = new HttpClient();
			string apiURL = "https://localhost:7146/api/KichCoAPI";

			var response = await httpClient.GetAsync(apiURL);
			string apiData = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<List<KichCoVM>>(apiData);
			return View(result);
		}
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(KichCoVM kichCoVM)
		{
			if (!ModelState.IsValid)
				return View(kichCoVM);

			var httpClient = new HttpClient();

			string apiURL = "https://localhost:7146/api/KichCoAPI";

			var json = JsonConvert.SerializeObject(kichCoVM);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await httpClient.PostAsync(apiURL, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAll");
			}
			ModelState.AddModelError("", "Create Sai roi");

			return View(kichCoVM);
		}
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/KichCoAPI/kichco/{id}";

			var response = await httpClient.GetAsync(apiURL);

			string apiData = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<KichCoVM>(apiData);
			return View(result);
		}

		public async Task<IActionResult> Edit(KichCoVM kichCoVM)
		{
			if (!ModelState.IsValid) return View(kichCoVM);

			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/KichCoAPI/{kichCoVM.Id}";

			var json = JsonConvert.SerializeObject(kichCoVM);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			//var content = new StringContent(JsonConvert.SerializeObject(capBacVM, Encoding.UTF8, "application/json");

			var response = await httpClient.PutAsync(apiURL, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAll");
			}
			ModelState.AddModelError("", "Edit sai roi be oi");

			return View(kichCoVM);
		}
		public async Task<IActionResult> Delete(Guid id)
		{
			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/KichCoAPI/{id}";

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
