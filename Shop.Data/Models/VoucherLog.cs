namespace Shop.Data.Models;
public class VoucherLog
{
    public int Id { get; set; }
    public int IdHoaDon { get; set; }
    public int IdVoucher { get; set; }
    public decimal TienTruocGiamGia { get; set; }
    public decimal SoTienGiam { get; set; }
    public int TrangThai { get; set; }
    public virtual HoaDon? HoaDon { get; set; }
    public virtual Voucher? Voucher { get; set; }
}
