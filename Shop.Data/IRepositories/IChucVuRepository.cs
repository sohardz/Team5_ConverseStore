using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.IRepositories;
public interface IChucVuRepository
{ 
    Task<List<ChucVu>> GetAllAsync();
}
