using Microsoft.AspNetCore.Mvc;
using Shop.Application.ViewModels;
using Shop.WebApp.Models;
using Shop.WebApp.Services;
using System.Diagnostics;

namespace Shop.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TServices _services;

    public HomeController(ILogger<HomeController> logger, TServices services)
    {
        _logger = logger;
        _services = services;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _services.GetAll<ChucVuVM>("https://localhost:5000/api/ChucVuAPI/GetAllChucVuVM"));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}