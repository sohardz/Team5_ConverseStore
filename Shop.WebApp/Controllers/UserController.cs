using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ViewModels.ViewModels;

namespace Shop.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }


        public async Task<IActionResult> ShowCart()
        {
            var userId = HttpContext.Session.GetString("userId");
            ViewData["userId"] = userId;
            if (!string.IsNullOrEmpty(userId))
            {
                var httpClient = new HttpClient();
                string cartDetailsApiURL = $"https://localhost:7146/api/CTGioHangAPI/ctgiohang/{userId}";
                string productDetailsApiURL = "https://localhost:7146/api/CTSanPhamAPI";

                var reponse1 = await httpClient.GetAsync(cartDetailsApiURL);
                var reponse2 = await httpClient.GetAsync(productDetailsApiURL);

                if(reponse1.IsSuccessStatusCode)
                {
                    var api1Data = await reponse1.Content.ReadAsStringAsync();
                    var result1 = JsonConvert.DeserializeObject<List<CTGioHangVM>>(api1Data);
                    ViewBag.listCartDetails = result1;
                }

                if(reponse2.IsSuccessStatusCode) 
                {
                    var api2Data = await reponse2.Content.ReadAsStringAsync();
                    var result2 = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(api2Data);
                    ViewBag.listCtsp = result2;
                }

                return View();
            }
            return RedirectToAction("Login", "Home");
        }

        public async Task<IActionResult> Pay()
        {
            var httpClient = new HttpClient();

            var userId = HttpContext.Session.GetString("userId");
            Guid id = Guid.Parse(userId);

            string cartDetailsApiURL = $"https://localhost:7146/api/CTGioHangAPI/ctgiohang/{userId}"; // get
            string billApiURL = "https://localhost:7146/api/HoaDonAPI"; // post
            string billDetailsApiURL = "https://localhost:7146/api/CTHoaDonAPI"; // post with userId

            var reponse1 = await httpClient.GetAsync(cartDetailsApiURL);

            if (reponse1.IsSuccessStatusCode)
            {
                var api1Data = await reponse1.Content.ReadAsStringAsync();
                var result1 = JsonConvert.DeserializeObject<List<CTGioHangVM>>(api1Data);
                
            }

            return View();
        }
    }
}
