namespace Shop.Data.Models;

public class GioHang
{
    public Guid IdKh { get; set; }
    public string Ma { get; set; }
    public string MoTa { get; set; }
    public int TrangThai { get; set; }
    public virtual KhachHang? KhachHang { get; set; }
    public ICollection<CTGioHang> CTGioHangs { get; set; }
}