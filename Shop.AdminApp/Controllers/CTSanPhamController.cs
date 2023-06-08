using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;
using System.Text;

namespace Shop.AdminApp.Controllers
{
    public class CTSanPhamController : Controller
    {
        public CTSanPhamController()
        {

        }

        public async Task<IActionResult> ShowAll()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7146/api/CTSanPhamAPI/";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CTSanPhamVM>>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Create(Guid sanphamId, Guid kichCoId, Guid giamgiaId, Guid mausacId, Guid danhmucId)
        {
            var httpClient = new HttpClient();
            string apiURL1 = "https://localhost:7146/api/SanPhamAPI/";
            var response = await httpClient.GetAsync(apiURL1);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<SanPhamVM>>(apiData);
            
            ViewBag.SanPham = result.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected =  sanphamId.ToString() == x.Id.ToString()
            });
            string apiURL2 = "https://localhost:7146/api/MauSacAPI/";
            var response1 = await httpClient.GetAsync(apiURL2);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<MauSacVM>>(apiData1);
            ViewBag.MauSac = result1.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = mausacId.ToString() == x.Id.ToString()
            });

            string apiURL3 = "https://localhost:7146/api/DanhMucAPI/";
            var response2 = await httpClient.GetAsync(apiURL3);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<List<DanhMuc>>(apiData2);
            ViewBag.DanhMuc = result2.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = danhmucId.ToString() == x.Id.ToString()
            });

            string apiURL4 = "https://localhost:7146/api/KichCoAPI/";
            var response3 = await httpClient.GetAsync(apiURL4);
            string apiData3 = await response3.Content.ReadAsStringAsync();
            var result3 = JsonConvert.DeserializeObject<List<KichCoVM>>(apiData3);
            ViewBag.KichCo = result3.Select(x => new SelectListItem()
            {
                Text = x.SoSize.ToString(),
                Value = x.Id.ToString(),
                Selected = kichCoId.ToString() == x.Id.ToString()
            });

            string apiURL5 = "https://localhost:7146/api/GiamGiaAPI/get-all-giamgia/";
            var response4 = await httpClient.GetAsync(apiURL5);
            string apiData4 = await response4.Content.ReadAsStringAsync();
            var result4 = JsonConvert.DeserializeObject<List<GiamGiaVM>>(apiData4);
            ViewBag.GiamGia = result4.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = giamgiaId.ToString() == x.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CTSanPhamVM cTSanPhamVM, Guid sanphamId, Guid kichCoId, Guid giamgiaId , Guid mausacId, Guid danhmucId)
        {
            if (!ModelState.IsValid)
                return View(cTSanPhamVM);
            
            var httpClient = new HttpClient();

            string apiURL1 = "https://localhost:7146/api/SanPhamAPI/";
            var respons = await httpClient.GetAsync(apiURL1);
            string apiData = await respons.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<SanPhamVM>>(apiData);
            ViewBag.SanPham = result.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected =  sanphamId.ToString() == x.Id.ToString() 
            });

            string apiURL2 = "https://localhost:7146/api/MauSacAPI/";
            var response1 = await httpClient.GetAsync(apiURL2);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<MauSacVM>>(apiData1);
            ViewBag.MauSac = result1.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = mausacId.ToString() == x.Id.ToString()
            });

            string apiURL3 = "https://localhost:7146/api/DanhMucAPI/";
            var response2 = await httpClient.GetAsync(apiURL3);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<List<DanhMuc>>(apiData2);
            ViewBag.DanhMuc = result2.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = danhmucId.ToString() == x.Id.ToString()
            });

            string apiURL4 = "https://localhost:7146/api/KichCoAPI/";
            var response3 = await httpClient.GetAsync(apiURL4);
            string apiData3 = await response3.Content.ReadAsStringAsync();
            var result3 = JsonConvert.DeserializeObject<List<KichCoVM>>(apiData3);
            ViewBag.KichCo = result3.Select(x => new SelectListItem()
            {
                Text = x.SoSize.ToString(),
                Value = x.Id.ToString(),
                Selected = kichCoId.ToString() == x.Id.ToString()
            });

            string apiURL5 = "https://localhost:7146/api/GiamGiaAPI/get-all-giamgia/";
            var response4 = await httpClient.GetAsync(apiURL5);
            string apiData4 = await response4.Content.ReadAsStringAsync();
            var result4 = JsonConvert.DeserializeObject<List<GiamGiaVM>>(apiData4);
            ViewBag.GiamGia = result4.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = giamgiaId.ToString() == x.Id.ToString()
            });


            cTSanPhamVM.IdSanPham = sanphamId;
            cTSanPhamVM.IdMauSac = mausacId;
            cTSanPhamVM.IdDanhMuc = danhmucId;
            cTSanPhamVM.IdGiamGia = giamgiaId;
            cTSanPhamVM.IdKichCo = kichCoId;

            string apiURL = "https://localhost:7146/api/CTSanPhamAPI/";
            var json = JsonConvert.SerializeObject(cTSanPhamVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await httpClient.PostAsync(apiURL, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "Sai roi");

            return View(cTSanPhamVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id, Guid sanphamId, Guid kichCoId, Guid giamgiaId, Guid mausacId, Guid danhmucId)
        {
            var httpClient = new HttpClient();

            string apiURL = $"https://localhost:7146/api/CTSanPhamAPI/ctsanpham/{id}";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CTSanPhamVM>(apiData);
            
            string apiURL1 = "https://localhost:7146/api/SanPhamAPI/";
            var response5 = await httpClient.GetAsync(apiURL1);
            string apiData6 = await response5.Content.ReadAsStringAsync();
            var result6 = JsonConvert.DeserializeObject<List<SanPhamVM>>(apiData6);

            ViewBag.SanPham = result6.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = result.IdSanPham.ToString() == x.Id.ToString()
            });
            string apiURL2 = "https://localhost:7146/api/MauSacAPI/";
            var response1 = await httpClient.GetAsync(apiURL2);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<MauSacVM>>(apiData1);
            ViewBag.MauSac = result1.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = result.IdMauSac.ToString() == x.Id.ToString()
            });

            string apiURL3 = "https://localhost:7146/api/DanhMucAPI/";
            var response2 = await httpClient.GetAsync(apiURL3);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<List<DanhMuc>>(apiData2);
            ViewBag.DanhMuc = result2.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = result.IdDanhMuc.ToString() == x.Id.ToString()
            });

            string apiURL4 = "https://localhost:7146/api/KichCoAPI/";
            var response3 = await httpClient.GetAsync(apiURL4);
            string apiData3 = await response3.Content.ReadAsStringAsync();
            var result3 = JsonConvert.DeserializeObject<List<KichCoVM>>(apiData3);
            ViewBag.KichCo = result3.Select(x => new SelectListItem()
            {
                Text = x.SoSize.ToString(),
                Value = x.Id.ToString(),
                Selected = result.IdKichCo.ToString() == x.Id.ToString()
            });

            string apiURL5 = "https://localhost:7146/api/GiamGiaAPI/get-all-giamgia/";
            var response4 = await httpClient.GetAsync(apiURL5);
            string apiData4 = await response4.Content.ReadAsStringAsync();
            var result4 = JsonConvert.DeserializeObject<List<GiamGiaVM>>(apiData4);
            ViewBag.GiamGia = result4.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = result.IdGiamGia.ToString() == x.Id.ToString()
            });

            
            
            //result.IdDanhMuc = danhmucId;
            //result.IdSanPham = sanphamId;
            //result.IdMauSac = mausacId;
            //result.IdKichCo = kichCoId;
            //result.IdGiamGia = giamgiaId;
            return View(result);
        }

        public async Task<IActionResult> Edit(CTSanPhamVM cTSanPhamVM, Guid sanphamId, Guid kichCoId, Guid giamgiaId, Guid mausacId, Guid danhmucId)
        {
            if (!ModelState.IsValid) return View(ModelState);

            var httpClient = new HttpClient();

            string apiURL1 = "https://localhost:7146/api/SanPhamAPI/";
            var respons = await httpClient.GetAsync(apiURL1);
            string apiData = await respons.Content.ReadAsStringAsync();
            var result9 = JsonConvert.DeserializeObject<List<SanPhamVM>>(apiData);
            ViewBag.SanPham = result9.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = sanphamId.ToString() == x.Id.ToString() /*x.Id.ToString() == cTSanPhamVM.IdSanPham.ToString()*/
            });

            string apiURL2 = "https://localhost:7146/api/MauSacAPI/";
            var response1 = await httpClient.GetAsync(apiURL2);
            string apiData1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<List<MauSacVM>>(apiData1);
            ViewBag.MauSac = result1.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = mausacId.ToString() == x.Id.ToString() /*x.Id.ToString() == cTSanPhamVM.IdMauSac.ToString()*/
            });

            string apiURL3 = "https://localhost:7146/api/DanhMucAPI/";
            var response2 = await httpClient.GetAsync(apiURL3);
            string apiData2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<List<DanhMuc>>(apiData2);
            ViewBag.DanhMuc = result2.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = danhmucId.ToString() == x.Id.ToString()/* x.Id.ToString() == cTSanPhamVM.IdDanhMuc.ToString()*/
            });

            string apiURL4 = "https://localhost:7146/api/KichCoAPI/";
            var response3 = await httpClient.GetAsync(apiURL4);
            string apiData3 = await response3.Content.ReadAsStringAsync();
            var result3 = JsonConvert.DeserializeObject<List<KichCoVM>>(apiData3);
            ViewBag.KichCo = result3.Select(x => new SelectListItem()
            {
                Text = x.SoSize.ToString(),
                Value = x.Id.ToString(),
                Selected = kichCoId.ToString() == x.Id.ToString()/* x.Id.ToString() == cTSanPhamVM.IdKichCo.ToString()*/
            });

            string apiURL5 = "https://localhost:7146/api/GiamGiaAPI/get-all-giamgia/";
            var response4 = await httpClient.GetAsync(apiURL5);
            string apiData4 = await response4.Content.ReadAsStringAsync();
            var result4 = JsonConvert.DeserializeObject<List<GiamGiaVM>>(apiData4);
            ViewBag.GiamGia = result4.Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString(),
                Selected = giamgiaId.ToString() == x.Id.ToString() /*x.Id.ToString() == cTSanPhamVM.IdGiamGia.ToString()*/
            });


            cTSanPhamVM.IdSanPham = sanphamId;
            cTSanPhamVM.IdMauSac = mausacId;
            cTSanPhamVM.IdDanhMuc = danhmucId;
            cTSanPhamVM.IdGiamGia = giamgiaId;
            cTSanPhamVM.IdKichCo = kichCoId;

            string apiURL = $"https://localhost:7146/api/CTSanPhamAPI/{cTSanPhamVM.Id}";
            var json = JsonConvert.SerializeObject(cTSanPhamVM);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "sai roi be oi");

            return View(cTSanPhamVM);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7146/api/CTSanPhamAPI/{id}";

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
