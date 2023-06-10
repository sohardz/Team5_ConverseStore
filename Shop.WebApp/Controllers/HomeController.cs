using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;
using Shop.WebApp.Models;
using System.Diagnostics;
using System.Text;

namespace Shop.WebApp.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}

	public async Task<IActionResult> Index()
	{
		var httpClient = new HttpClient();
		string apiURL = "https://localhost:7146/api/CTSanPhamAPI/";

		var response = await httpClient.GetAsync(apiURL);
		string apiData = await response.Content.ReadAsStringAsync();
		var result = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(apiData);
		return View(result);
	}

	public async Task<IActionResult> Register()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Register(KhachHangVM khachHangVM)
	{
		var httpClient = new HttpClient();
		string apiURL = "https://localhost:7146/api/KhachHangAPI/create-khachhang";

		var json = JsonConvert.SerializeObject(khachHangVM);
		var content = new StringContent(json, Encoding.UTF8, "application/json");

		var response = await httpClient.PostAsync(apiURL, content);
		if (response.IsSuccessStatusCode)
		{
			return RedirectToAction("Index");
		}
		else
		{
			ModelState.AddModelError("", "Sai roi");

			return View(khachHangVM);
		}
	}

	public async Task<IActionResult> Login()
	{
		return View();
	}

	[HttpGet]
	public async Task<IActionResult> Login(string username, string password)
	{
		var httpClient = new HttpClient();
		string apiURL = "https://localhost:7146/api/KhachHangAPI";

		var response = await httpClient.GetAsync(apiURL);
		var apiData = await response.Content.ReadAsStringAsync();
		var result = JsonConvert.DeserializeObject<List<KhachHangVM>>(apiData);

		foreach (var i in result)
		{
			if (i.TenTaiKhoan == username && i.MatKhau == password)
			{
				var userId = i.Id.ToString();
				HttpContext.Session.SetString("userId", userId);
				return RedirectToAction("Index");
			}
		}

		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}