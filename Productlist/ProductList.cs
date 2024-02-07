
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
            else if(category.Length<1) 
            {
                ForegroundColor=ConsoleColor.Red;
                WriteLine("The category can not be empty, the product will not be saved");
                ResetColor();
                continue;
            }
            Write("ProductName: ");
            string name = ReadLine();
            if (name.Length<1)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("The productname can not be empty, the product will not be saved");
                ResetColor();
                continue;
            }
            Write("Price: ");
            string price = ReadLine();
            int productPrice = 0;
            if (!Int32.TryParse(price, out productPrice)|| productPrice<1)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("The price has to be an integer and greater than 0");
                ResetColor();
                continue;
            }
            Products.Add(new Product(category, name, productPrice));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The product was succesfully added.");
            ResetColor();


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
        List<Product> sortedProducts = sortList(Products);
        WriteLine("Enter product to search for: ");
        string productToSearchFor = ReadLine();
        int index = -1;
        index=sortedProducts.FindIndex(product=>product.ProductName.Contains(productToSearchFor));
        if (index < -1)
        {
            Console.WriteLine("The product was not found.");
        }
        else 
        {
            
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
                line++;
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
