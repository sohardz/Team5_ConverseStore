namespace Shop.Data.Models;
public class NhanVien
{
    public int Id { get; set; }
    public int IdCv { get; set; }
    public string TenTaiKhoan { get; set; }
    public string MatKhau { get; set; }
    public string Anh { get; set; }
    public string Email { get; set; }
    public int TrangThai { get; set; }
    public virtual ChucVu? ChucVu { get; set; }
    public ICollection<HoaDon> HoaDons { get; set; }
}
