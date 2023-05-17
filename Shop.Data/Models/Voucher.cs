namespace Shop.Data.Models;
public class Voucher
{
    public int Id { get; set; }
    public string Ma { get; set; }
    public string Ten { get; set; }
    public decimal SoTienCan { get; set; }
    public decimal SoTienGiam { get; set; }
    public DateTime NgayApDung { get; set; }
    public DateTime NgayKetThuc { get; set; }
    public int SoLuong { get; set; }
    public string MoTa { get; set; }
    public int TrangThai { get; set; }
    public ICollection<HoaDon> HoaDons { get; set; }
}
