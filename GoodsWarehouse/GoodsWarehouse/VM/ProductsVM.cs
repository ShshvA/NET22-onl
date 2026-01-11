using GoodsWarehouse.Models;

namespace GoodsWarehouse.VM
{
    public class ProductsVM
    {
        public List<Product> ProductsList { get; set; } = new List<Product>();
        public List<ProductType> ProductTypesList { get; } = Enum.GetValues<ProductType>().ToList();
        public SortedDictionary<int, string> Report { get; set; } = new SortedDictionary<int, string>();
    }
}
