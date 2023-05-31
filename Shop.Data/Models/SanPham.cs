namespace Shop.Data.Models;
public class SanPham
{
    public int Id { get; set; }
    public string Ten { get; set; }
    public int TrangThai { get; set; }
    public ICollection<CTSanPham> CTSanPhams { get; set; }
}
