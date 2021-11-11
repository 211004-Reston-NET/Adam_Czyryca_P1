using System;
using System.Collections.Generic;
using TTGBL;
using TTGModel;

namespace TTGUI
{
    public class CurrentCustomer : IMenu
    {
        private ICustomerBL _custBL;

        public CurrentCustomer(ICustomerBL p_custBL)
        {
            _custBL = p_custBL;
        }
        public void Menu()
        {
            List<Customer> ListOfCustomers = _custBL.GetCustomer(ShowCustomers._findCustName);

            
            //Console.WriteLine(ListOfCustomers[0].ToString());
            if (ListOfCustomers.Count == 0)
            {
                Console.WriteLine(
                        "-------------------------\n" +
                        "No result found try entering a more Specific name\n" +
                        "[0] - Go back\n" +
                        "-------------------------\n"
                    );
                
            }
            else
            {
                Console.WriteLine("This is the search result");
                foreach (Customer customer in ListOfCustomers)
                {
                    Console.WriteLine(
                        "-------------------------\n" +
                        $"{customer}\n" +
                        "-------------------------\n"
                    );
                }
                Console.WriteLine("[0] - Go back");
            }
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.CustomerMenu;
                default:
                    Console.WriteLine("Enter a valid response");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    return MenuType.CurrentCustomer;
            }
        }
    }
}