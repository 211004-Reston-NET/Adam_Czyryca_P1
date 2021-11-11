using System;
using System.Collections.Generic;
using TTGBL;
using TTGModel;

namespace TTGUI
{
    public class ShowStores : IMenu
    {
        public IStoreBL _storeBL;//IstoreBL
        public ShowStores(IStoreBL p_storeBL)//IStoreBL
        {
            _storeBL=p_storeBL;
        }

        public void Menu()
        {
            Console.WriteLine(
            "------------------------------\n" +
            $"Current User: {SingletonCustomer.Customer.Name}\n" +
            "------------------------------\n"
            );
            Console.WriteLine("Stores in Database");
            List<Store> ListOfStores = _storeBL.GetAllStores();

            foreach (Store store in ListOfStores)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine(store);
                Console.WriteLine("------------------------");
            }
            Console.WriteLine("[1] - search for store");
            Console.WriteLine("[0] - Go back");
            
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("Enter a name for the store you want to find");
                    Console.Write("Store: ");
                    SingletonStore.store.Name = Console.ReadLine();
                    return MenuType.CurrentStore;
                case "0":
                    if(SingletonUser.User==1)
                    {
                        return MenuType.MainCustomerMenu;
                    }
                    return MenuType.TestingMenu;
                default:
                    Console.WriteLine("Enter a valid response");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    return MenuType.ShowStores;
            }
        }
    }
}