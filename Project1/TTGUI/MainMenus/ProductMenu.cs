using System;
namespace TTGUI 
{
    public class ProductMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine(String.Join(Environment.NewLine,
            "____________________________________",
            "Welcome to the Product page",
            "What would you like to do?",
            "[1] Add a Product",
            "[2] View products",
            "[0] Go back",
            "______________________________________"

            )); 
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {

                
                case "1":
                    return MenuType.AddProductsMenu;
                case "2":
                    return MenuType.ShowProducts;
                case "0": 
                    //return MenuType.OrdersMenu;
                    return MenuType.TestingMenu;
                default:
                 Console.WriteLine(" Enter a Valid option ");
                 return MenuType.ProductMenu;;
            }
        }
    }
}