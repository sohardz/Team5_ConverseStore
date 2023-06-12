namespace Shop.Data.Models;

public class MauSac
{
	public Guid Id { get; set; }
	public string Ma { get; set; }
	public string Ten { get; set; }
	public int TrangThai { get; set; }
	public ICollection<CTSanPham> CTSanPhams { get; set; }
}