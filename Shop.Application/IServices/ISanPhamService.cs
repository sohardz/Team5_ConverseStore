using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface ISanPhamService
    {
        public Task<List<SanPhamVM>> GetAllSanPham();
        public Task<SanPhamVM> GetById(int id);
        public Task<int> Sua(SanPhamVM sp);
        public Task<int> Them(SanPhamVM sp);
        public Task<int> Xoa(int id);
    }
}
