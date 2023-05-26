namespace Shop.Data.Models;

public class Anh
{
    public Guid Id { get; set; }
    public Guid? IdCtsp { get; set; }
    public string Ma { get; set; }
    public string DuongDan { get; set; }
    public int TrangThai { get; set; }
    public virtual CTSanPham? CTSanPham { get; set; }
}