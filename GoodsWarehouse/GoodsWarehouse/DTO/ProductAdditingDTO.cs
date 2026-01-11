using GoodsWarehouse.Models;

namespace GoodsWarehouse.DTO
{
    public class ProductAdditingDTO
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public ProductType Type { get; set; } = ProductType.None;
        public string Price { get; set; }
        public int NumberOfProducts { get; set; }
    }
}
