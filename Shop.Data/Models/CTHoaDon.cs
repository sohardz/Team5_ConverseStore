namespace Shop.Data.Models;
public class CTHoaDon
{
    public int Id { get; set; }
    public int IdHoaDon { get; set; }
    public int IdSanPham { get; set; }
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public virtual CTSanPham? CTSanPham { get; set; }
    public virtual HoaDon? HoaDon { get; set; }

}
