using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using System.Text;

namespace Shop.AdminApp.Controllers
{
	public class KhachHangController : Controller
	{
		public async Task<IActionResult> ShowAll()
		{
			var httpClient = new HttpClient();
			string apiURL = "https://localhost:7146/api/KhachHangAPI";

			var response = await httpClient.GetAsync(apiURL);
			string apiData = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<List<KhachHangVM>>(apiData);
			return View(result);
		}
		public async Task<IActionResult> Create(Guid capBacId)
		{
			var httpClient = new HttpClient();
			string apiURL1 = "https://localhost:7146/api/CapBacAPI/get-all-capbac/";
			var response1 = await httpClient.GetAsync(apiURL1);
			string apiData1 = await response1.Content.ReadAsStringAsync();
			var result9 = JsonConvert.DeserializeObject<List<CapBacVM>>(apiData1);
			ViewBag.CapBac = result9.Select(x => new SelectListItem()
			{
				Text = x.Ten,
				Value = x.Id.ToString(),
				Selected = capBacId.ToString() == x.Id.ToString() /*x.Id.ToString() == cTSanPhamVM.IdSanPham.ToString()*/
			});
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(KhachHangVM khachhangVM, Guid capBacId)
		{
			if (!ModelState.IsValid)
				return View(khachhangVM);

			var httpClient = new HttpClient();

			string apiURL1 = "https://localhost:7146/api/CapBacAPI/get-all-capbac/";
			var response1 = await httpClient.GetAsync(apiURL1);
			string apiData1 = await response1.Content.ReadAsStringAsync();
			var result9 = JsonConvert.DeserializeObject<List<CapBacVM>>(apiData1);
			ViewBag.Capbac = result9.Select(x => new SelectListItem()
			{
				Text = x.Ten,
				Value = x.Id.ToString(),
				Selected = capBacId.ToString() == x.Id.ToString() /*x.Id.ToString() == cTSanPhamVM.IdSanPham.ToString()*/
			});
			khachhangVM.IdBac = capBacId;

			string apiURL = "https://localhost:7146/api/KhachHangAPI";
			var json = JsonConvert.SerializeObject(khachhangVM);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await httpClient.PostAsync(apiURL, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAll");
			}
			ModelState.AddModelError("", "Sai roi");

			return View(khachhangVM);
		}
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id, Guid capBacId)
		{
			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/KhachHangAPI/khachhang/{id}";

			var response = await httpClient.GetAsync(apiURL);

			string apiData = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<KhachHangVM>(apiData);

			string apiURL1 = "https://localhost:7146/api/CapBacAPI/get-all-capbac";
			var response1 = await httpClient.GetAsync(apiURL1);
			string apiData1 = await response1.Content.ReadAsStringAsync();
			var result9 = JsonConvert.DeserializeObject<List<CapBacVM>>(apiData1);
			ViewBag.SanPham = result9.Select(x => new SelectListItem()
			{
				Text = x.Ten,
				Value = x.Id.ToString(),
				Selected = result.IdBac.ToString() == x.Id.ToString() /*x.Id.ToString() == cTSanPhamVM.IdSanPham.ToString()*/
			});
			return View(result);
		}

		public async Task<IActionResult> Edit(KhachHangVM khachHangVM)
		{
			if (!ModelState.IsValid) return View(khachHangVM);

			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/KhachHangAPI/{khachHangVM.Id}";

			var json = JsonConvert.SerializeObject(khachHangVM);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			//var content = new StringContent(JsonConvert.SerializeObject(capBacVM, Encoding.UTF8, "application/json");

			var response = await httpClient.PutAsync(apiURL, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAll");
			}
			ModelState.AddModelError("", "sai roi be oi");

			return View(khachHangVM);
		}
		public async Task<IActionResult> Delete(Guid id)
		{
			var httpClient = new HttpClient();
			string apiURL = $"https://localhost:7146/api/KhachHangAPI/{id}";

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
