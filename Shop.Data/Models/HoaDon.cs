namespace Shop.Data.Models;

public class HoaDon
{
	public Guid Id { get; set; }
	public Guid? IdKh { get; set; }
	public Guid? IdVoucher { get; set; }
	public string Ma { get; set; }
	public string MaKh { get; set; }
	public DateTime NgayTao { get; set; }
	public DateTime? NgayThanhToan { get; set; }
	public DateTime? NgayShip { get; set; }
	public DateTime? NgayNhan { get; set; }
	public string TenKh { get; set; }
	public string DiaChi { get; set; }
	public decimal TongTien { get; set; }
	public int TrangThai { get; set; }
	public string SdtNguoiNhan { get; set; }
	public string? SdtNguoiShip { get; set; }
	public string? TenNguoiShip { get; set; }
	public int PhanTramGiamGia { get; set; }
	public int SoDiemSuDung { get; set; }
	public decimal SoTienQuyDoi { get; set; }
	public decimal TienShip { get; set; }
	public virtual KhachHang? KhachHang { get; set; }
	public ICollection<CTHoaDon> CTHoaDons { get; set; }
	public virtual Voucher? Voucher { get; set; }
}