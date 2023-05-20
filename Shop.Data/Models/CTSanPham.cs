namespace Shop.Data.Models;
public class CTSanPham
{
    public int Id { get; set; }
    public int IdSanPham { get; set; }
    public decimal GiaNhap { get; set; }
    public decimal GiaBan { get; set; }
    public int SoLuongTon { get; set; }
    public string MoTa { get; set; }
    public int IdKichCo { get; set; }
    public int IdMauSac { get; set; }
    public int IdDanhMuc { get; set; }
    public int IdGiamGia { get; set; }
    public int TrangThai { get; set; }
    public ICollection<CTGioHang> CTGioHangs { get; set; }
    public ICollection<CTHoaDon> CTHoaDons { get; set; }
    public ICollection<Anh> Anhs { get; set; }
    public virtual KichCo? KichCo { get; set; }
    public virtual MauSac? MauSac { get; set; }
    public virtual DanhMuc? DanhMuc { get; set; }
    public virtual SanPham? SanPham { get; set; }
    public virtual GiamGia? GiamGia { get; set; }


}
