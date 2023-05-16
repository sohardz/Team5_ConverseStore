namespace Shop.Data.Models;
public class VoucherKhachHang
{
    public int Id { get; set; }
    public int IdVoucher { get; set; }
    public int IdKh { get; set; }
    public int TrangThai { get; set; }
    public virtual Voucher? Voucher { get; set; }
    public virtual KhachHang? KhachHang { get; set; }
}
