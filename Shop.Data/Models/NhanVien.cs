namespace Shop.Data.Models;

public class NhanVien
{
	public Guid Id { get; set; }
	public Guid IdCv { get; set; }
	public string Ma { get; set; }
	public string HoVaTen { get; set; }
	public string TenTaiKhoan { get; set; }
	public string MatKhau { get; set; }
	public string Anh { get; set; }
	public string Email { get; set; }
	public int TrangThai { get; set; }
	public virtual ChucVu? ChucVu { get; set; }
}