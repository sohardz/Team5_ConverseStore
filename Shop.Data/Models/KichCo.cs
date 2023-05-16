namespace Shop.Data.Models;
public class KichCo
{
    public int Id { get; set; }
    public int SoSize { get; set; }
    public int TrangThai { get; set; }
    public virtual CTSanPham? CTSanPham { get; set; }
}
