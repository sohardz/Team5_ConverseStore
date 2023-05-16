namespace Shop.Data.Models;
public class KhachHang
{
    public int Id { get; set; }
    public string MaKh { get; set; }
    public string HoVaTen { get; set; }
    public string TenTaiKhoan { get; set; }
    public string MatKhau { get; set; }
    public string SoDienThoai { get; set; }
    public DateTime NgaySinh { get; set; }
    public string DiaChi { get; set; }
    public int GioiTinh { get; set; }
    public string GhiChu { get; set; }
    public int SoLanMua { get; set; }
    public int TrangThai { get; set; }
    public int IdDiem { get; set; }
    public virtual ICollection<VoucherKhachHang> VoucherKhachHangs { get; set; }
    public virtual GioHang? GioHang { get; set; }
    public virtual ViDiem? ViDiem { get; set; }
}
