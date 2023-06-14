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
            //ViewData["userId"] = userId;
            if (!string.IsNullOrEmpty(userId))
            {
                var httpClient = new HttpClient();
                string cartDetailsApiURL = $"https://localhost:7146/api/CTGioHangAPI/ctgiohang/{userId}";
                string productDetailsApiURL = "https://localhost:7146/api/CTSanPhamAPI";

                var cartDetailsApiResponse = await httpClient.GetAsync(cartDetailsApiURL);
                var productDetailsApiResponse = await httpClient.GetAsync(productDetailsApiURL);

                if (cartDetailsApiResponse.IsSuccessStatusCode)
                {
                    var cartDetailsApiData = await cartDetailsApiResponse.Content.ReadAsStringAsync();
                    var lstCtgh = JsonConvert.DeserializeObject<List<CTGioHangVM>>(cartDetailsApiData);
                    ViewBag.listCartDetails = lstCtgh;
                }

                if (productDetailsApiResponse.IsSuccessStatusCode)
                {
                    var productDetailsApiData = await productDetailsApiResponse.Content.ReadAsStringAsync();
                    var lstCtsp = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(productDetailsApiData);
                    ViewBag.listCtsp = lstCtsp;
                }

                return View();
            }
            return RedirectToAction("Login", "Home");
        }

        public async Task<IActionResult> ShowOrderSuccess(Guid id)
        {
            var httpClient = new HttpClient();
            var billApiURL = $"https://localhost:7146/api/HoaDonAPI/find-order/{id}";
            var billApiResponse = await httpClient.GetAsync(billApiURL);
            var billApiData = await billApiResponse.Content.ReadAsStringAsync();
            var hoadon = JsonConvert.DeserializeObject<HoaDonVM>(billApiData);

            if (billApiResponse.IsSuccessStatusCode)
            {
                var billDetailsApiURL = $"https://localhost:7146/api/CTHoaDonAPI/get-all/{hoadon.Id}";
                var billDetailsApiResponse = await httpClient.GetAsync(billDetailsApiURL);
                var billDetailsApiData = await billDetailsApiResponse.Content.ReadAsStringAsync();
                var lstBildetails = JsonConvert.DeserializeObject<List<CTHoaDonVM>>(billDetailsApiData);
                ViewBag.lstcthd = lstBildetails;
                ViewBag.hoadon = hoadon;
                return View();
            }
            return BadRequest();
        }

        public async Task<IActionResult> ConfirmOrder()
        {
            // khởi tạo httpclient
            var httpClient = new HttpClient();

            // lấy khách hàng id
            var userId = HttpContext.Session.GetString("userId");
            Guid id = Guid.Parse(userId);

            // lấy list chi tiết sản phẩm để lấy giá bán và phục vụ cập nhật số lượng
            string productDetailsApiURL = "https://localhost:7146/api/CTSanPhamAPI"; // get
            var productDetailResponse = await httpClient.GetAsync(productDetailsApiURL);
            var productDetailResponseData = await productDetailResponse.Content.ReadAsStringAsync();
            var lstCtspVM = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(productDetailResponseData);

            // lấy user để gán thông tin vào hóa đơn (số điện thoại người nhận, tên khách hàng, địa chỉ)
            string userApiURL = $"https://localhost:7146/api/KhachHangAPI/khachhang/{userId}";
            var userApiResponse = await httpClient.GetAsync(userApiURL);
            var userApiResponseData = await userApiResponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<KhachHangVM>(userApiResponseData);

            // lấy thông tin giỏ hàng để tạo hóa đơn và chi tiết hóa đơn
            string ctghApiURL = $"https://localhost:7146/api/CTGioHangAPI/ctgiohang/{userId}"; // get      
            var ctghApiResponse = await httpClient.GetAsync(ctghApiURL);

            // phục vụ tạo hóa đơn và chi tiết hóa đơn


            // nếu lấy thông tin giỏ hàng thành công -> nghiệp vụ
            if (ctghApiResponse.IsSuccessStatusCode)
            {
                var api1Data = await ctghApiResponse.Content.ReadAsStringAsync();
                var lstCtghVM = JsonConvert.DeserializeObject<List<CTGioHangVM>>(api1Data);

                HoaDonVM hoadonVM = new()
                {
                    Id = Guid.NewGuid(),
                    IdKh = id,
                    Ma = "hd2",
                    MaKh = user.Ma,
                    TenKh = user.HoVaTen,
                    NgayTao = DateTime.Now,
                    DiaChi = user.DiaChi,
                    TienShip = 0,
                    TongTien = 0,
                    TrangThai = 1,
                    SdtNguoiNhan = user.SoDienThoai,
                    SdtNguoiShip = "0",
                    SoDiemSuDung = 0,
                    SoTienQuyDoi = 0,
                    TenNguoiShip = "",
                    PhanTramGiamGia = 0,
                };

                string hoadonApiURL = "https://localhost:7146/api/HoaDonAPI"; // post
                var hoadonJson = JsonConvert.SerializeObject(hoadonVM);
                var hoadonContent = new StringContent(hoadonJson, Encoding.UTF8, "application/json");
                var hoadonApiResponse = await httpClient.PostAsync(hoadonApiURL, hoadonContent);

                if (hoadonApiResponse.IsSuccessStatusCode)
                {
                    // với mỗi giỏ hàng chi tiết
                    foreach (var item in lstCtghVM)
                    {
                        // tạo chi tiết hóa đơn
                        var cthdVM = new CTHoaDonVM()
                        {
                            Id = Guid.NewGuid(),
                            IdHoaDon = (Guid)hoadonVM.Id,
                            IdCtsp = item.IdCtsp,
                            SoLuong = item.SoLuong,
                            DonGia = lstCtspVM.FirstOrDefault(x => x.Id == item.IdCtsp).GiaBan,
                            TrangThai = 1,
                        };

                        // thêm vào database
                        string cthdApiURL = "https://localhost:7146/api/CTHoaDonAPI"; // post with userId
                        var cthdJson = JsonConvert.SerializeObject(cthdVM);
                        var cthdContent = new StringContent(cthdJson, Encoding.UTF8, "application/json");
                        var cthdApiResponse = await httpClient.PostAsync(cthdApiURL, cthdContent);

                        // cập nhật số lượng
                        var ctsp = lstCtspVM.FirstOrDefault(x => x.Id == item.IdCtsp);
                        ctsp.SoLuongTon -= item.SoLuong;
                        var updateProductdetailApiURL = $"https://localhost:7146/api/CTSanPhamAPI/{ctsp.Id}";
                        var updateProductdetailJson = JsonConvert.SerializeObject(ctsp);
                        var updateProductdetailContent = new StringContent(updateProductdetailJson, Encoding.UTF8, "application/json");
                        var updateProductdetailResponse = await httpClient.PutAsync(updateProductdetailApiURL, updateProductdetailContent);

                        // xóa chi tiết giỏ hàng
                        var deleteCartdetailsApiURL = $"https://localhost:7146/api/CTGioHangAPI/{item.Id}"; // delete
                        var deleteCartdetailReponse = await httpClient.DeleteAsync(deleteCartdetailsApiURL);
                    }
                    return RedirectToAction("ShowOrderSuccess", new { id = hoadonVM.Id });
                }
                else
                {
                    return BadRequest("Không tạo được hóa đơn");
                }
            }
            else
            {
                return BadRequest("Không lấy được chi tiết giỏ hàng");
            }
        }

        public async Task<IActionResult> AddToCart(Guid id)
        {
            var userIdinSession = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userIdinSession)) return RedirectToAction("Login", "Home");

            Guid userId = Guid.Parse(userIdinSession);

            var httpClient = new HttpClient();
            var ctghApiURL = "https://localhost:7146/api/CTGioHangAPI";
            var ctghVM = new CTGioHangVM()
            {
                Id = Guid.NewGuid(),
                IdCtsp = id,
                IdKh = userId,
                SoLuong = 1
            };

            var json = JsonConvert.SerializeObject(ctghVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var ctghApiResponse = await httpClient.PostAsync(ctghApiURL, content);
            if (ctghApiResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowCart");
            }
            return BadRequest(ctghApiResponse);
        }

        public async Task<IActionResult> CheckOrder()
        {
            var userIdinSession = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userIdinSession)) return RedirectToAction("Login", "Home");

            Guid userId = Guid.Parse(userIdinSession);

            var httpClient = new HttpClient();
            var hoadonApiURL = $"https://localhost:7146/api/HoaDonAPI/find-order-by-userid/{userId}";

            var hoadonApiResponse = await httpClient.GetAsync(hoadonApiURL);

            var hoadonApiResponseData = await hoadonApiResponse.Content.ReadAsStringAsync();
            var listHoadon = JsonConvert.DeserializeObject<List<HoaDonVM>>(hoadonApiResponseData);
            return View(listHoadon);
        }
    }
}
