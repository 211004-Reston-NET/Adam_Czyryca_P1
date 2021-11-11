using System;
using TTGModel;
using TTGBL;
namespace TTGUI
{
    public class AddCustomerMenu : IMenu
    {
        //create a new customer obj named _cust
        private static Customer _cust = new Customer();

        //create an undefined ICustomerBL obj names _custbl
        public ICustomerBL _custBL;

        //this classes constructor
        public AddCustomerMenu(ICustomerBL p_custBL)
        {
            //instantiate _custBL with p_custBL
            _custBL = p_custBL;
        }
        public void Menu()
        {

            Console.WriteLine(
            "____________________________\n" +
            "Add Customer Menu\n" +
            $"Name - {_cust.Name}\n" +
            $"Address -{_cust.Address}\n" +
            $"email/phone number - {_cust.EmailPhone}\n" +
            "[1] - Enter your for Name\n" +
            "[2] - Enter your for Address\n" +
            "[3] - Enter your Email or Phone number\n" +
            "[4] - Submit Information\n" +
            "[0] - Go Back\n" +
            "______________________________\n"
            );

        }

        public MenuType Navigation()
        {
            string UserChoice = Console.ReadLine();

            switch (UserChoice)
            {

                case "1":
                    try
                    {
                        Console.Write("Name: ");
                        _cust.Name = Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.ReadLine();
                    }

                    return MenuType.AddCustomerMenu;
                case "2":
                    Console.Write("Address: ");
                    _cust.Address = Console.ReadLine();
                    return MenuType.AddCustomerMenu;
                case "3":
                    Console.Write("Email/Phone: ");
                    _cust.EmailPhone = Console.ReadLine();
                    return MenuType.AddCustomerMenu;
                case "4":
                    try
                    {
                        _custBL.AddCustomer(_cust); 
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("one of the entered values was too long");
                        Console.WriteLine("press enter to continue...");
                        Console.ReadLine();
                    }
                    
                    Console.WriteLine("customer has been added successfully");
                    Console.WriteLine("Press enter to continue..");
                    Console.ReadLine();
                    return MenuType.AddCustomerMenu;
                case "0":
                    if(SingletonUser.User == 1)
                    {
                        return MenuType.CustomerMenu;
                    }
                    else if(SingletonUser.User == 2) 
                    {
                        return MenuType.TestingMenu;
                    }
                    else
                    {
                        return MenuType.LogInMenu;
                    }

                default:
                    Console.WriteLine("Please choose one of the options listed above");
                    Console.WriteLine("press enter to continue...");
                    Console.ReadLine();
                    return MenuType.AddCustomerMenu;
            }
        }
    }
}