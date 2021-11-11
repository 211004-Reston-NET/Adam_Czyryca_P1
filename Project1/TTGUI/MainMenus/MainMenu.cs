using System;

namespace TTGUI
{

    public class MainMenu : IMenu
    {
        public void Menu()
        {

            Console.WriteLine(
            "___________________________\n" +
            "[1] - Customer LogIn\n" +
            "[2] - Manager LogIn\n" +
            "[3] - Sign up\n" +
            "[0] - Exit\n" +
            "____________________________"
            );
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    return MenuType.LogInMenu;
                case "2":
                    return MenuType.ManagerLogInMenu;
                case "3":
                    return MenuType.AddCustomerMenu;
                case "0":
                    return MenuType.Exit;
                default:
                    Console.WriteLine(" Enter a Valid option ");
                    return MenuType.MainMenu;
            }
        }
    }
}