using System;
using System.Collections.Generic;
using TTGBL;
using TTGModel;

namespace TTGUI
{
    public class CurrentStore : IMenu
    {
        private IStoreBL _storeBL;

        public CurrentStore(IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }

        public void Menu()
        {
            List<Store> ListOfStores = _storeBL.GetStore(SingletonStore.store.Name);

            //Console.WriteLine(SingletonStore.store.Name);
            Console.WriteLine("search result");
            foreach (Store Store in ListOfStores)
            {
                Console.WriteLine(
                    "-------------------------\n" +
                    $"{Store}\n" +
                    "-------------------------\n"
                );
            }
            Console.WriteLine("[0] - Go back");
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    SingletonStore.store.Name = "";
                    return MenuType.ShowStores;
                default:
                    Console.WriteLine("Enter a valid response");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    return MenuType.CurrentStore;
            }
        }
    }
}