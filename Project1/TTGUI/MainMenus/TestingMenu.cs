using System;
using TTGBL;

namespace TTGUI
{

    public class TestingMenu : IMenu
    {

        public void Menu()
        {

            Console.WriteLine(
            "------------------------------\n" +
            $"Current User: {SingletonCustomer.Customer.Name}\n" +
            "------------------------------\n" +
            // $"Current User: {SingletonCustomer.Customer.Id}\n" +
            // "------------------------------\n" +
            // $"Current User: {SingletonCustomer.Customer.EmailPhone}\n" +
            "___________________________\n" +
            "Welcome to the Manager Main menu\n" +
            "[1] - CustomerMenu\n" +
            "[2] - StoreMenu\n" +
            "[3] - OrdersMenu\n" +
            "[4] - ProductMenu\n" +
            "[5] - LineItemMenu\n" +
            "[0] - Exit\n" +
            "____________________________"
            );
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "5":
                    return MenuType.LineItemMenu;
                case "4":
                    return MenuType.ProductMenu;
                case "3":
                    return MenuType.OrdersMenu;
                case "2":
                    return MenuType.StoreMenu;
                case "1":
                    return MenuType.CustomerMenu;
                case "0":
                    return MenuType.Exit;
                default:
                    Console.WriteLine(" Enter a Valid option ");
                    return MenuType.MainMenu;
            }
        }
    }
}