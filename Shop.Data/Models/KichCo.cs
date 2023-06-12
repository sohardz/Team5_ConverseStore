namespace Shop.Data.Models;

public class KichCo
{
	public Guid Id { get; set; }
	public string Ma { get; set; }
	public int SoSize { get; set; }
	public int TrangThai { get; set; }
	public ICollection<CTSanPham> CTSanPhams { get; set; }
}