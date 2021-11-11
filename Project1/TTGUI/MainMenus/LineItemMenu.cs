using System;
namespace TTGUI
{
    public class LineItemMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine(String.Join(Environment.NewLine,
            "___________________________________________",
            "Welcome to the LineItem information page",
            "What would you like to do?",
            "[1] AddLineItem",
            "[2] View LineItems",
            "[0] Go back",
            "___________________________________________"
            ));
        }

        public MenuType Navigation()
        {
            string UserChoice = Console.ReadLine();

            switch (UserChoice)
            {
                case "2":
                    return MenuType.ShowLineItems;
                case "1":
                    return MenuType.AddLineItemsMenu;
                case "0":
                    //return MenuType.MainMenu;
                    return MenuType.TestingMenu;
                default:
                    Console.WriteLine(" Enter a Valid option ");
                    return MenuType.LineItemMenu;
            }
        }
    }
}