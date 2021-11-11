using System;

namespace TTGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            IFactory factory = new MenuFactory();
            IMenu page = factory.GetMenu(MenuType.MainMenu);

            while (repeat)
            {
                Console.Clear();
                page.Menu();
                MenuType currentPage = page.Navigation();

                if (currentPage == MenuType.Exit)
                {
                    Console.WriteLine("You are exiting the application");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    repeat = false;
                }
                else
                {
                    page = factory.GetMenu(currentPage);
                }
            }
        }
    }
}
