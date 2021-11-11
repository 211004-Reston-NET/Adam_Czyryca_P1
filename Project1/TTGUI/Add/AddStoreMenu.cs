using System;
using TTGModel;
using TTGBL;
namespace TTGUI
{
    public class AddStoreMenu : IMenu
    {

        private static Store _store = new Store();
        private IStoreBL _storeBL;

        public AddStoreMenu(IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public void Menu()
        {

            Console.WriteLine(
            "______________________________\n" +
            "Add a new Store\n" +
            $"Name - {_store.Name}\n" +
            $"Address - {_store.Address}\n" +
            "[1] - Input value for Name\n" +
            "[2] - Input value for Address\n" +
            "[3] - Add store\n" +
            "[0] - Go Back\n" +
            "______________________________"
            );
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {

                case "1":
                    _store.Name = Console.ReadLine();
                    return MenuType.AddStoreMenu;
                case "2":
                    _store.Address = Console.ReadLine();
                    return MenuType.AddStoreMenu;
                case "3":
                    if (String.IsNullOrEmpty(_store.Name))
                    {
                        Console.WriteLine("Name and Address cant be null");
                        Console.WriteLine("Press enter to continue..");
                        Console.ReadLine();
                    }
                    else
                    {
                        _storeBL.AddStore(_store);
                        Console.WriteLine("Store has been added successfully");
                        Console.WriteLine("Press enter to continue..");
                        Console.ReadLine();
                        _store.Name = "";
                        _store.Address = "";
                    }

                    return MenuType.AddStoreMenu;
                case "4":
                    Console.WriteLine(_store.Name);
                    Console.WriteLine(_store.Name);
                    Console.ReadLine();
                    return MenuType.AddStoreMenu;
                case "0":
                    return MenuType.StoreMenu;
                default:
                    Console.WriteLine(" Enter a Valid option ");
                    return MenuType.CustomerMenu;
            }
        }
    }
}