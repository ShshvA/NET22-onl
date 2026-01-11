using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GoodsWarehouse.Models
{
    public enum ProductType
    {
        None,
        Fruits,
        Vegetables,
        Berries
    }
    public class Product
    {
        public Product(string name, ProductType type, string price, int numberOfProducts)
        {
            Id = ++_id;
            Name = name;
            Type = type;
            Price = price;
            NumberOfProducts = numberOfProducts;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ProductType Type { get; set; } = ProductType.None;
        public string Price { get; set; }
        public int NumberOfProducts { get; set; }

        private static int _id = 0;
    }
}
