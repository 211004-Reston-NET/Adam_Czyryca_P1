using System;

namespace TTGUI
{

    public class MainCustomerMenu : IMenu
    {
        public void Menu()
        {

            Console.WriteLine(
            "------------------------------\n" +
            $"Current User: {SingletonCustomer.Customer.Name}\n" +
            "------------------------------\n" +
            "___________________________\n" +
            "Welcome to the customer main menu\n" +
            "[1] - orders\n" +
            "[2] - View store locations\n" +
            "[3] - view products\n" +
            "[4] - Back to LogIn\n" +
            "[0] - Exit application\n" +
            "____________________________"
            );
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    return MenuType.OrdersMenu;
                case "2":
                    return MenuType.ShowStores;
                case "3":
                    return MenuType.ShowProducts;
                case "4":
                    return MenuType.MainMenu;
                case "0":
                    return MenuType.Exit;
                default:
                    Console.WriteLine(" Enter a Valid option ");
                    return MenuType.MainMenu;
            }
        }
    }
}