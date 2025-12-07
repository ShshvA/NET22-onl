namespace DocAccountingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Register register = new Register();

            Document[] docs = new Document[]
                {
                new SupplyGoodsContract(),
                new FinancialInvoice(),
                new EmployeeContract(),
                new SupplyGoodsContract("", -10),
                new SupplyGoodsContract("Яблоки", 1000),
                new EmployeeContract("Никита", new DateTime()),
                new EmployeeContract("Олег", new DateTime(2030,1,1)),
                new FinancialInvoice(-1, 0),
                new FinancialInvoice(31232.42, 43244),
                new SupplyGoodsContract(),
                new FinancialInvoice(),
                new EmployeeContract()
                };

            foreach (Document doc in docs)
            {
                register.SaveDoc(doc);
            }

            foreach (Document doc in docs)
            {
                register.GetDocInfo(doc);
            }
        }
    }
}
