
using System;

namespace TTGUI
{
    public class CustomerMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine(
             "------------------------------\n" +
             $"Current User: {SingletonCustomer.Customer.Name}\n" +
             "------------------------------\n" +
             "_______________________________________________\n" +
             "Welcome to the Customer information page\n" +
             "What would you like to do?\n" +
             "[1] Show all Customers\n" +
             "[2] Add new customer\n" +
             "[0] Go back\n" +
             "_______________________________________________\n");

        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {

                case "1":
                    return MenuType.ShowCustomers;
                case "2":
                    return MenuType.AddCustomerMenu;
                case "0":
                    //return MenuType.MainMenu;
                    return MenuType.TestingMenu;
                default:
                    Console.WriteLine(" Enter a Valid option ");
                    return MenuType.CustomerMenu;
            }
        }
    }
}