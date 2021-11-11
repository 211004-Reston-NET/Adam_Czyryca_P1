using System;
using TTGModel;
using TTGBL;
namespace TTGUI
{
    public class AddProductsMenu : IMenu
    {

        private static Product _products = new Product();
        private IProductBL _productsBL;

        public AddProductsMenu(IProductBL p_productsBL)
        {
            _productsBL = p_productsBL;
        }
        public void Menu()
        {
            Console.WriteLine(
            "____________________________\n" +
            "Add Customer Menu\n" +
            $"Name - {_products.Name}\n" +
            $"Price - { _products.Price}\n" +
            $"Description - { _products.Description}\n" +
            $"Category - { _products.Catagory}\n" +
            "[1] - Enter the products Name\n" +
            "[2] - Enter the products price\n" +
            "[3] - Enter the products Description\n" +
            "[4] - Enter the products Category\n" +
            "[5] - Submit Information\n" +
            "[0] - Go Back\n" +
            "______________________________\n"
            );
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {


                case "1":
                    Console.Write("Name: ");
                    _products.Name = Console.ReadLine();
                    return MenuType.AddProductsMenu;
                case "2":
                    Console.Write("Price: ");
                    _products.Price = Convert.ToDouble(Console.ReadLine());
                    return MenuType.AddProductsMenu;
                case "3":
                    Console.Write("Description: ");
                    _products.Description = Console.ReadLine();
                    return MenuType.AddProductsMenu;
                case "4":
                    Console.Write("Category: ");
                    _products.Catagory = Console.ReadLine();
                    return MenuType.AddProductsMenu;
                case "5":
                    _productsBL.AddProduct(_products);
                    Console.WriteLine("the Product has been added successfully");
                    Console.WriteLine("Press enter to continue..");
                    Console.ReadLine();
                    _products.Name = "";
                    _products.Price = 0;
                    _products.Description="";
                    _products.Catagory="";
                    return MenuType.AddProductsMenu;
                case "0":
                    return MenuType.ProductMenu;
                default:
                    Console.WriteLine(" Enter a Valid option ");
                    return MenuType.CustomerMenu;
            }
        }
    }
}