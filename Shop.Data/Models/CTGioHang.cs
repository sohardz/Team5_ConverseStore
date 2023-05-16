namespace Shop.Data.Models;
public class CTGioHang
{
    public int Id { get; set; }
    public int IdKh { get; set; }
    public int IdSanPham { get; set; }
    public int SoLuong { get; set; }
    public ICollection<CTSanPham> CTSanPhams { get; set; }
    public virtual GioHang? GioHang { get; set; }
}
