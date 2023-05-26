namespace Shop.Data.Models;

public class CTHoaDon
{
    public Guid Id { get; set; }
    public Guid IdHoaDon { get; set; }
    public Guid IdCtsp { get; set; }
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public int TrangThai { get; set; }
    public virtual CTSanPham? CTSanPham { get; set; }
    public virtual HoaDon? HoaDon { get; set; }
}