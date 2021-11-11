using System;
using System.Collections.Generic;
using TTGBL;
using TTGModel;

namespace TTGUI
{
    public class ManagerLogInMenu : IMenu
    {
        private ICustomerBL _ICustBL;
        private ILogInBL _ILogBL;
        public ManagerLogInMenu(ILogInBL p_LogBL, ICustomerBL p_ICustBL)
        {
            _ILogBL = p_LogBL;
            _ICustBL = p_ICustBL;
        }
        public void Menu()
        {
            Console.WriteLine(
            "___________________________\n" +
            "Welcome to the manager LogIn Menu\n" +
            $"[1] - Name: {SingletonCustomer.Customer.Name}\n" +
            $"[2] - Email/Phone: {SingletonCustomer.Customer.EmailPhone} \n" +
            "[3] - LogIn\n" +
            "[0] - Exit\n" +
            "____________________________"
            );
        }

        public MenuType Navigation()
        {
            String UserChoice = Console.ReadLine();
            switch (UserChoice)
            {
                case "1":
                    Console.Write("Name: ");
                    try
                    {
                        SingletonCustomer.Customer.Name = Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Name can only be letters");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                    return MenuType.ManagerLogInMenu;
                case "2":
                    Console.Write("Email/phone: ");
                    SingletonCustomer.Customer.EmailPhone = Console.ReadLine();
                    return MenuType.ManagerLogInMenu;
                case "3":
                    Boolean match = false;
                    try
                    {
                        match = _ILogBL.VerifyCustomerID(SingletonCustomer.Customer.Name, SingletonCustomer.Customer.EmailPhone);

                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("User not found");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("values cant be null");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("values cant be null");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                    //Boolean match = _ILogBL.VerifyCustomerID(SingletonCustomer.Customer.Name, SingletonCustomer.Customer.EmailPhone);
                    if (match == true)
                    {
                        SingletonCustomer.Customer = _ICustBL.GetMatchingCustomer(SingletonCustomer.Customer.Name, SingletonCustomer.Customer.EmailPhone);
                        SingletonUser.User = 2;
                        return MenuType.TestingMenu;
                    }
                    return MenuType.LogInMenu;
                case "0":
                    return MenuType.MainMenu;
                default:
                    Console.WriteLine("Please choose one of the choices provided");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}