using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ViewModels
{
    public class CTSanPhamVM
    {
        public int Id { get; set; }
        public string TenSP { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public string MoTa { get; set; }
        public int SoSize { get; set; }
        public string TenMauSac { get; set; }
        public string TenDanhMuc { get; set; }
        public string MaGiamGia { get; set; }
        public int IdSanPham { get; set; }
        public int IdKichCo { get; set; }
        public int IdMauSac { get; set; }
        public int IdDanhMuc { get; set; }
        public int IdGiamGia { get; set; }
        public int TrangThai { get; set; }
    }
}
