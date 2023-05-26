using Shop.Application.ViewModels;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices;

public interface ICTGioHangServices
{
    Task<List<CTGioHangVM>> GetAll();
    Task<int> Create(CTGioHangVM ctgh);
    Task<int> Edit(CTGioHangVM ctgh);
    Task<int> Delete(Guid id);
    Task<CTGioHangVM> GetById(Guid id);
}
