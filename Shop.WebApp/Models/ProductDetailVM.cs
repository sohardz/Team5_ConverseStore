using Shop.ViewModels.ViewModels;

namespace Shop.WebApp.Models
{
    public class ProductDetailVM
    {
        public DanhMucVM Category { get; set; }

        public CTSanPhamVM Product { get; set; }

        public List<CTSanPhamVM> RelatedProducts { get; set; }

        public List<CTSanPhamVM> ProductImages { get; set; }
    }
}
