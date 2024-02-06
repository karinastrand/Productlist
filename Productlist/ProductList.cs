
namespace Productlist;

internal class ProductList
{
    List<Product> Products=new List<Product>();

    public ProductList()
    {
        Products = new List<Product>();
    }

    public void AddProducts()
    {
        WriteLine("Add products, Category, ProductName and Price, Price has to be an integer");
        WriteLine("When you want to finish write q");
        while (true) 
        {
            Write("Category (q to quit): ");
            string category = ReadLine();
            if (category.ToLower().Trim() == "q")
            {
                break;
            }
            Write("ProductName: ");
            string name = ReadLine();
            Write("Price: ");
            string price = ReadLine();
            int productPrice = 0;
            Int32.TryParse(price, out productPrice);
            Products.Add(new Product(category,name,productPrice));


        }
        
    }
    public void ShowProducts()
    {
        WriteLine("Category".PadLeft(10) + "Product".PadLeft(10) + "Price".PadLeft(10));
        foreach (Product prod in Products) 
        {
            Console.WriteLine(PrintProduct(prod));
        }
        
    }
    public void SearchProducts()
    {
        WriteLine();
    }
    public void sumPrice()
    {

    }
    public string PrintProduct(Product productToPrint)
    {
        
        return $"{productToPrint.Category.PadLeft(10)} {productToPrint.ProductName.PadLeft(10)} {(productToPrint.Price).ToString().PadLeft(10)}";
    }

}
