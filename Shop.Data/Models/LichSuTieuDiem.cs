namespace Shop.Data.Models;
public class LichSuTieuDiem
{
    public int Id { get; set; }
    public int SoDiemDaDung { get; set; }
    public DateTime NgaySuDung { get; set; }
    public int SoDiemCong { get; set; }
    public int TrangThai { get; set; }
    public int IdQuyDoi { get; set; }
    public int IdDiem { get; set; }
    public int IdHoaDon { get; set; }
    public virtual ViDiem? ViDiem { get; set; }
    public virtual QuyDoiDiem? QuyDoiDiem { get; set; }
    public virtual HoaDon? HoaDon { get; set; }
}
