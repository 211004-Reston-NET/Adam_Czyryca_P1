using System;

namespace TTGUI
{
    public class StoreMenu : IMenu
    {
        public static int storeId;
        public void Menu()
        {
            Console.WriteLine(String.Join(Environment.NewLine,
            "____________________________________",
            "Welcome to the store page",
            "What would you like to do?",
            "[1] Show Store list",
            "[2] Add a store",
            "[3] view Store inventory",
            "[0] Go back",
            "______________________________________"

            ));
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                // case "4":
                //     return MenuType.ShowStores;
                // case "3":
                //     return MenuType.AddStoreMenu;

                case "1":
                    return MenuType.ShowStores;
                case "2":
                    return MenuType.AddStoreMenu;
                case "3":
                    try
                    {
                        Console.WriteLine("enter the ID of a store to view its inventory");
                        Console.Write("Name:");
                        storeId = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("not A Valid input");
                        Console.WriteLine("press enter to continue...");
                        Console.ReadLine();
                    }
                    return MenuType.ShowStoreInventory;
                case "0":
                    //return MenuType.MainMenu;
                    return MenuType.TestingMenu;
                default:
                    Console.WriteLine(" Enter a Valid option ");
                    return MenuType.StoreMenu;
            }
        }
    }
}