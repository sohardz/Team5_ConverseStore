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

	public IActionResult Login()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Login(LoginVM login)
	{
		var httpClient = new HttpClient();
		string apiURL = $"https://localhost:7146/api/KhachHangAPI/login?username={login.Username}&password={login.Password}";

		var response = await httpClient.PostAsync(apiURL, new StringContent(""));

		if (response.IsSuccessStatusCode)
		{
			var apiData = await response.Content.ReadAsStringAsync();
			HttpContext.Session.SetString("userId", apiData);
			return RedirectToAction("Index");
		}
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}