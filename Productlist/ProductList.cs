
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
            if (Int32.TryParse(price, out productPrice))
            {
                Console.ForegroundColor=ConsoleColor.Green;
                Products.Add(new Product(category, name, productPrice));
                Console.WriteLine("The product was succesfully added.");
                ResetColor();
            }
            else 
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The price has to be an integer, {price} is not.  ");
                ResetColor();
                Console.WriteLine("Price: ");
                price = ReadLine();
                if (Int32.TryParse(price, out productPrice))
                {
                    ForegroundColor = ConsoleColor.Green;
                    Products.Add(new Product(category, name, productPrice));
                    Console.WriteLine("The product was succesfully added.");
                    ResetColor();
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    Products.Add(new Product(category, name, productPrice));
                    Console.WriteLine($"The price has to be an integer, {price} is not.  ");
                    Console.WriteLine("The product is added with price=0, use change price in the menu to correct it.");
                    ResetColor();
                  
                }
            }


        }
        
    }
    public void ShowProducts()
    {
        List<Product> sortedProducts = sortList(Products);
        ForegroundColor=ConsoleColor.Green;
        WriteLine("Category".PadRight(30) + "Product".PadRight(30) + "Price");
        ResetColor();
        foreach (Product prod in sortedProducts) 
        {
            Console.WriteLine(PrintProduct(prod));
        }
        ForegroundColor = ConsoleColor.Blue;
        WriteLine("".PadRight(30)+"Total amount:".PadRight(30)+Products.Sum(product=>product.Price));
        ResetColor();
    }
    public void SearchProducts()
    {
        WriteLine("Enter product to search for: ");
        string productToSearchFor = ReadLine();
        int index = -1;
        index=Products.FindIndex(product=>product.ProductName.Contains(productToSearchFor));
        if (index < 0)
        {
            Console.WriteLine("The product was not found.");
        }
        else 
        {
            List<Product> sortedProducts = sortList(Products);
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Category".PadRight(30) + "Product".PadRight(30) + "Price");
            ResetColor();
            int line= 0;
            foreach (Product prod in sortedProducts)
            {
                if (line==index)
                {
                    ForegroundColor= ConsoleColor.Cyan;
                }
                Console.WriteLine(PrintProduct(prod));
                ResetColor();
            }
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("".PadRight(30) + "Total amount:".PadRight(30) + Products.Sum(product => product.Price));
            ResetColor();

        }
    }
    public List<Product> sortList(List<Product> products)
    {
       return  Products.OrderBy(product => product.Price).ToList();

    }
    public string PrintProduct(Product productToPrint)
    {
        
        return $"{productToPrint.Category.PadRight(30)}{productToPrint.ProductName.PadRight(30)}{(productToPrint.Price)}";
    }

}
