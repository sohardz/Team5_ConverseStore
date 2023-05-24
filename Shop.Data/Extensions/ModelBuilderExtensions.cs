using Microsoft.EntityFrameworkCore;

namespace Shop.Data.Extensions;
public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        //Lưu ý bắt buộc phải triển khai có ID vì nó cần đảm bảo vẹn toàn khi có các khóa phụ ở các bảng khác
    }
}
