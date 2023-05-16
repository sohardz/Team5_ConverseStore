namespace Shop.Data.Models;
public class ViDiem
{
    public int Id { get; set; }
    public int TongDiem { get; set; }
    public int SoDiemDaDung { get; set; }
    public int SoDiemDaCong { get; set; }
    public int TrangThai { get; set; }
    public virtual KhachHang? KhachHang { get; set; }
    public ICollection<LichSuTieuDiem> lichSuTieuDiems { get; set; }
}
