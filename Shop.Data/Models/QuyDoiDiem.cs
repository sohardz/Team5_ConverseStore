namespace Shop.Data.Models;

public class QuyDoiDiem
{
    public int Id { get; set; }
    public decimal TienTichDiem { get; set; }
    public decimal TienTieuDiem { get; set; }
    public int TrangThai { get; set; }
    public ICollection<LichSuTieuDiem> LichSuTieuDiems { get; set; }
}
