using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAccountingSystem
{
    internal class SupplyGoodsContract : Document
    {
        public SupplyGoodsContract()
        {
            base.Type = "SupplyGoodsContract";
        }

        public SupplyGoodsContract(string productType, int numberOfProducts) : this()
        {
            ProductType = string.IsNullOrWhiteSpace(productType) ? "Отсутствует" : productType;
            NumberOfProducts = int.IsNegative(numberOfProducts) ? 0 : numberOfProducts;
        }

        public override void GetDocInfo()
        {
            base.GetDocInfo();
            Console.WriteLine($"\t Тип товаров: {ProductType} \n" +
                $"\t Количество товаров: {(NumberOfProducts == 0 ? "Отсутствует" : NumberOfProducts)} \n");
        }

        public string ProductType { get; set; } = "Неизвестно";

        public int NumberOfProducts { get; set; } = 0;
    }
}
