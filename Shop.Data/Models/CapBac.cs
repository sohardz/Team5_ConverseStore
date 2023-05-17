namespace Shop.Data.Models;
public class CapBac
{
    public int Id { get; set; }
    public string Ten { get; set; }
    public int SoDiemCan { get; set; }
    public int TrangThai { get; set; }
    public ICollection<KhachHang> KhachHangs { get; set; }
}
