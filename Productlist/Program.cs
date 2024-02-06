using Productlist;
ProductList myProductList=new ProductList();
while(true)
{ 
    WriteLine("---------------");
    WriteLine("Menu");
    WriteLine("----------------");
    WriteLine("1. Add Product");
    WriteLine("2. Show Productlist");
    WriteLine("3. Search");
    WriteLine("Quit: write 'q'");
    string answer=ReadLine();
    if (answer.ToLower().Trim()=="q")
    {
        break;
    }
    switch(answer)
    {
        case "1":
            {
                myProductList.AddProducts();
                break;
            }
        case "2":
            {
                myProductList.ShowProducts();
                break;
            }
        case "3":
            {
                myProductList.SearchProducts();
                break;
            }
        default: 
            {
                Console.WriteLine("Write 1,2,3 or q");
                break;
            }
    }
}