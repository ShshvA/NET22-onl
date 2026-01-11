using GoodsWarehouse.DTO;
using GoodsWarehouse.Interfaces;
using GoodsWarehouse.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Globalization;

namespace GoodsWarehouse.Services
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            return _productsList;
        }

        public Product GetProductById(int id)
        {
            return _productsList.FirstOrDefault(x => x.Id == id);
        }

        public void AddProduct(ProductAdditingDTO product)
        {
            Product newProduct = new Product(product.Name, product.Type, product.Price.Replace(',', '.'), product.NumberOfProducts);
            _productsList.Add(newProduct);
        }

        public void UpdateProduct(ProductAdditingDTO product)
        {
            Product oldProduct = _productsList.First(x => x.Id == product.Id);
            oldProduct.Name = product.Name;
            oldProduct.Type = product.Type;
            oldProduct.Price = product.Price.Replace(',', '.');
            oldProduct.NumberOfProducts = product.NumberOfProducts;
        }

        public void DeleteProduct(int id)
        {
            _productsList.Remove(_productsList.First(x => x.Id == id));
        }

        public SortedDictionary<int, string> GetReport()
        {
            SortedDictionary<int, string> report = new SortedDictionary<int, string>();
            foreach (Product product in _productsList)
            {
                var productPrice = double.Parse(product.Price, CultureInfo.InvariantCulture) * product.NumberOfProducts;

                string currentVal = report.GetValueOrDefault((int)product.Type, "0");
                double newValue = double.Parse(currentVal, CultureInfo.InvariantCulture) + productPrice;
                report[(int)product.Type] = newValue.ToString("F2").Replace(',', '.');

                string currentValOverall = report.GetValueOrDefault(-1, "0");
                double newValueOverall = double.Parse(currentValOverall, CultureInfo.InvariantCulture) + productPrice;
                report[-1] = newValueOverall.ToString("F2").Replace(',', '.');
            }

            return report;
        }

        private List<Product> _productsList = new List<Product>();
    }
}
