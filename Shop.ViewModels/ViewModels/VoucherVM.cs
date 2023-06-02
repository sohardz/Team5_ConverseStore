namespace Shop.ViewModels.ViewModels;

public class VoucherVM
{
    public Guid? Id { get; set; }
    public string Ma { get; set; }
    public string Ten { get; set; }
    public decimal SoTienCan { get; set; }
    public decimal SoTienGiam { get; set; }
    public DateTime NgayApDung { get; set; }
    public DateTime NgayKetThuc { get; set; }
    public int SoLuong { get; set; }
    public string MoTa { get; set; }
    public int TrangThai { get; set; }
}
