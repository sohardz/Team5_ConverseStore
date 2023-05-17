using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.IRepositories;
public interface IAllRepositories<TEntities> where TEntities : class
{ // Interface này chấp nhập mọi class (Dùng Generic)
    DbSet<TEntities> Entities { get; set; } // Tạo 1 DbSet để CRUD dữ liệu
    Task<IEnumerable<TEntities>> GetAllAsync(); // Lấy tất cả các đối tượng trong DBset
    Task<TEntities> GetOneAsync(IKey key); // Lấy 1
    bool AddOneAsync(TEntities entity); // Thêm 1
    bool AddManyAsync(IEnumerable<TEntities> entity); // Thêm nhiều
    bool DeleteOneAsync(TEntities entity); // Xóa 1
    bool DeleteManyAsync(IEnumerable<TEntities> entity); // Xóa nhiều
    bool UpdateOneAsync(TEntities entity); // Sửa 1
    bool UpdateManyAsync(IEnumerable<TEntities> entity); // Sửa nhiều
}
