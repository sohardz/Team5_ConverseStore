namespace Shop.Data.Models;

public class ChucVu
{
    public int Id { get; set; }
    public string Ten { get; set; }
    public int TrangThai { get; set; }
    public ICollection<NhanVien> NhanViens { get; set; }
}
