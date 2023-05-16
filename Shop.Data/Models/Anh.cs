namespace Shop.Data.Models;
public class Anh
{
    public int Id { get; set; }
    public int IdCTSP { get; set; }
    public string DuongDan { get; set; }
    public int TrangThai { get; set; }
    public virtual CTSanPham? CTSanPham { get; set; }
}
