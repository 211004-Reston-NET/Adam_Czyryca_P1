using System;
using System.Collections.Generic;
using TTGBL;
using TTGModel;

namespace TTGUI
{
    public class ShowCustomers : IMenu
    {
        private ICustomerBL _custBL;
        public static string _findCustName;
        public ShowCustomers(ICustomerBL p_custBL)
        {
            _custBL=p_custBL;
        }
        public void Menu()
        {
            Console.WriteLine("Registered Customers");
            List<Customer> ListOfCustomers = _custBL.GetAllCustomers();
            foreach (Customer customer in ListOfCustomers)
            {
                Console.WriteLine(
                    "-------------------------\n"+
                    $"{customer}\n"+
                    "-------------------------\n"
                ); 
            }
            Console.WriteLine("[1] - search for customer");
            Console.WriteLine("[0] - Go back");
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("Enter a name for the customer you want to find");
                    _findCustName = Console.ReadLine();
                    return MenuType.CurrentCustomer;
                case "0":
                    return MenuType.CustomerMenu;
                default:
                    Console.WriteLine("Enter a valid response");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    return MenuType.ShowCustomers;
            }
        }
    }
}