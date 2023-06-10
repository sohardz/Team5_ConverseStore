namespace Shop.Data.Models;

public class KhachHang
{
    public Guid Id { get; set; }
    public string Ma { get; set; }
    public string HoVaTen { get; set; }
    public string TenTaiKhoan { get; set; }
    public string MatKhau { get; set; }
    public string SoDienThoai { get; set; }
    public string Email { get; set; }
    public DateTime NgaySinh { get; set; }
    public string DiaChi { get; set; }
    public int GioiTinh { get; set; }
    public string GhiChu { get; set; }
    public int SoDiem { get; set; } 
    public int TrangThai { get; set; }
    public Guid? IdBac { get; set; }
    public virtual GioHang? GioHang { get; set; }
    public virtual CapBac? CapBac { get; set; }
    public ICollection<HoaDon> HoaDons { get; set; }
}