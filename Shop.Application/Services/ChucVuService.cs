using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.IRepositories;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public class ChucVuService : IChucVuService
    {
        private readonly IAllRepositories<ChucVu> _chucVuRepository;

        public ChucVuService(IAllRepositories<ChucVu> chucVuRepository)
        {
            _chucVuRepository = chucVuRepository;
        }

        public async Task<List<ChucVuVM>> GetAllChucVu()
        {
            IEnumerable<ChucVu> query = await _chucVuRepository.GetAllAsync();
            List<ChucVuVM> result = new();
            foreach (var x in query)
            {
                ChucVuVM vm = new()
                {
                    Id = x.Id,
                    Ten = x.Ten,
                    TrangThai = x.TrangThai,
                };
                result.Add(vm);
            }
            return result;
        }
    }
}
