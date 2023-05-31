namespace Shop.Data.Models;

public class CTGioHang
{
    public Guid Id { get; set; }
    public Guid IdKh { get; set; }
    public Guid IdCtsp { get; set; }
    public int SoLuong { get; set; }
    public virtual CTSanPham? CTSanPham { get; set; }
    public virtual GioHang? GioHang { get; set; }
}