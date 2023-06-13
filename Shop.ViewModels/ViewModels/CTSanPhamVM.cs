namespace Shop.ViewModels.ViewModels;

public class CTSanPhamVM
{
	public Guid? Id { get; set; }
	public string Ma { get; set; }
	public string? TenSP { get; set; }
	public decimal GiaNhap { get; set; }
	public decimal GiaBan { get; set; }
	public int SoLuongTon { get; set; }
	public string MoTa { get; set; }
	public int? SoSize { get; set; }
	public string? TenMauSac { get; set; }
	public string? TenDanhMuc { get; set; }
	public string? MaGiamGia { get; set; }
	public string? AnhBanDau { get; set; }
	public Guid IdSanPham { get; set; }
	public Guid IdKichCo { get; set; }
	public Guid IdMauSac { get; set; }
	public Guid IdDanhMuc { get; set; }
	public Guid IdGiamGia { get; set; }
	public int TrangThai { get; set; }
	public List<string> Anhs { get; set; } = new List<string>();
}
