namespace Shop.Data.Models;
public class DanhMuc
{
    public int Id { get; set; }
    public string Ten { get; set; }
    public int TrangThai { get; set; }
    public virtual CTSanPham? CTSanPham { get; set; }
}
