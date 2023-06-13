using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;
using System.Text;

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
        public async Task<IActionResult> AddToCart(Guid id)
        {

			var httpClient = new HttpClient();
			string apiURL = "https://localhost:7146/api/CTSanPhamAPI/";

			var response = await httpClient.GetAsync(apiURL);
			string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(apiData);

            //string apiURL2 = $"https://localhost:7146/api/CTSanPhamAPI/ctsanpham/{id}";
            //var response2 = await httpClient.GetAsync(apiURL);
            //string apiData2 = await response2.Content.ReadAsStringAsync();
            //var result2 = JsonConvert.DeserializeObject<CTSanPhamVM>(apiData2);

            var userId = HttpContext.Session.GetString("userId");
            var y = Guid.Parse(userId);
            
            if (!string.IsNullOrEmpty(userId))
            {
				string cartDetailsApiURL = $"https://localhost:7146/api/CTGioHangAPI/ctgiohang/{userId}";
				var response1 = await httpClient.GetAsync(cartDetailsApiURL);
				string apiData1 = await response1.Content.ReadAsStringAsync();
				var result1 = JsonConvert.DeserializeObject<List<CTGioHangVM>>(apiData1);
				
				List<CTGioHangVM> cartcr = result1;

                CTGioHangVM obj = new()
                {
                    IdCtsp = id,
                    IdKh = y,
                    SoLuong = 1
                };
                if (cartcr.Any(x => x.IdCtsp == id))
                {
                    obj.SoLuong = cartcr.FirstOrDefault(x => x.IdCtsp == id && x.IdKh == y).SoLuong + 1;
					string cartDetailsApiURL1 = $"https://localhost:7146/api/CTGioHangAPI/{userId}";
					var json = JsonConvert.SerializeObject(obj);
					var content = new StringContent(json, Encoding.UTF8, "application/json");
					var response6 = await httpClient.PutAsync(cartDetailsApiURL1, content);
                    if (response6.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ShowCart");
                    }
                    else
                    {
                        return BadRequest();
                    }    
                }
                else
                {
					string cartDetailsApiURL1 = $"https://localhost:7146/api/CTGioHangAPI/";
					var json = JsonConvert.SerializeObject(obj);
					var content = new StringContent(json, Encoding.UTF8, "application/json");
					var response6 = await httpClient.PostAsync(cartDetailsApiURL1, content);
                    if (response6.IsSuccessStatusCode) 
                    {
						return RedirectToAction("ShowCart");
					}
					else
					{
						return BadRequest();
					}

				}
                //if (cartDetails.Any(c => c.UserId == id && c.ProductId == productId))
                

            }

			return RedirectToAction("ShowCart");

		}
    }
}
