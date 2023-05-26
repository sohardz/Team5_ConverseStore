namespace Shop.Data.Models;

public class CTSanPham
{
    public Guid Id { get; set; }
    public Guid IdCtsp { get; set; }
    public string Ma { get; set; }
    public decimal GiaNhap { get; set; }
    public decimal GiaBan { get; set; }
    public int SoLuongTon { get; set; }
    public string MoTa { get; set; }
    public Guid IdKichCo { get; set; }
    public Guid IdMauSac { get; set; }
    public Guid IdDanhMuc { get; set; }
    public Guid IdGiamGia { get; set; }
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