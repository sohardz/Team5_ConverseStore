using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface ISanPhamService
    {
        public Task<List<SanPhamVM>> GetAll();
        public Task<SanPhamVM> GetById(int id);
        public Task<int> Edit(SanPhamVM sp);
        public Task<int> Create(SanPhamVM sp);
        public Task<int> Delete(int id);
    }
}
