using Microsoft.AspNetCore.Authentication;
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
        /* Check login ở services
		 * người dùng đăng nhập -> tài khoản mật khẩu -> apiURL -> api -> services check đúng sai -> trả về guid -> gán lại cho session "userId"
		 */
        var httpClient = new HttpClient();
        string apiURL = $"https://localhost:7146/api/KhachHangAPI/login?username={login.Username}&password={login.Password}";

        var response = await httpClient.PostAsync(apiURL, new StringContent(""));

        if (response.IsSuccessStatusCode)
        {
            var apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<string>(apiData);
            HttpContext.Session.SetString("userId", result);
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("userId");
        return RedirectToAction("Index");
    }

    public IActionResult Blog()
    {
        var idUser = HttpContext.ToString();
        ViewData["idUser"] = idUser;
        if (!string.IsNullOrEmpty(idUser))
            return View();
        return RedirectToAction("Login");
    }

    public ActionResult BlogDetails()
    {
        var idUser = HttpContext.ToString();
        ViewData["idUser"] = idUser;
        if (!string.IsNullOrEmpty(idUser))
            return View();
        return RedirectToAction("Login");
    }

    public ActionResult Contact()
    {
        var idUser = HttpContext.ToString();
        ViewData["idUser"] = idUser;
        if (!string.IsNullOrEmpty(idUser))
            return View();
        return RedirectToAction("Login");
    }

    public ActionResult Tracking()
    {
        var idUser = HttpContext.ToString();
        ViewData["idUser"] = idUser;
        if (!string.IsNullOrEmpty(idUser))
            return View();
        return RedirectToAction("Login");
    }

    public ActionResult Elements()
    {
        var idUser = HttpContext.ToString();
        ViewData["idUser"] = idUser;
        if (!string.IsNullOrEmpty(idUser))
            return View();
        return RedirectToAction("Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}