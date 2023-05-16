namespace Shop.Data.Models;
public class SanPhamGiamGia
{
    public int Id { get; set; }
    public int IdSanPham { get; set; }
    public int IdGiamGia { get; set; }
    public decimal DonGia { get; set; }
    public decimal SoTienConLai { get; set; }
    public int TrangThai { get; set; }
    public virtual CTSanPham? CTSanPham { get; set; }
    public virtual GiamGia? GiamGia { get; set;}
}
