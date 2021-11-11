using System;
using TTGModel;
using TTGBL;
using System.Collections.Generic;


namespace TTGUI
{
    public class AddOrderMenu : IMenu
    {

        private static Orders _Orders = new Orders();
        //string ProdName;
        private IOrderBL _OrderBL;
        private ICustomerBL _custBL;

        private IStoreBL _storeBL;

        public AddOrderMenu(IOrderBL p_OrderssBL, ICustomerBL p_prodBL, IStoreBL p_storeBL)
        {
            _OrderBL = p_OrderssBL;
            _custBL = p_prodBL;
            _storeBL = p_storeBL;
        }
        public void Menu()
        {
            Console.WriteLine(
            "____________________________\n" +
            "Add Orders Menu\n" +
            $"Customer - {SingletonCustomer.Customer.Name}\n" +
            $"Store-{SingletonStore.store.Name}\n" +
            //$"total - {_Orders.Total}\n" +
            "[1] - Enter the Name of a store for order pickup\n" +
            //"[2] - Add prodducts to order\n" +
            "[2] - view your orders\n" +
            //"[4] - Submit Information\n" +
            "[0] - Go Back\n" +
            "______________________________\n"
            );

        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {

                case "1":

                    Console.Write("Store Name: ");
                    SingletonStore.store.Name = Console.ReadLine();
                    List<Store> FoundStore = new List<Store>();
                    FoundStore = _storeBL.GetStore(SingletonStore.store.Name);
                    try 
                    {
                        String test =FoundStore[0].Name;
                        
                    }
                    catch(System.ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Enter a More specific name or check that the store exists");
                        Console.WriteLine("press enter to continue...");
                        Console.ReadLine();
                        return MenuType.AddOrderMenu;
                    }
                   
                        Console.WriteLine($"Is this correct [Y] [N]: {FoundStore[0].Name}");
                        String result2 = Console.ReadLine();
                        if (result2.ToUpper() == "Y")
                        {
                            _Orders.StoreFront = FoundStore[0].Id;
                            SingletonStore.store = FoundStore[0];
                            Console.WriteLine("Press enter to continue placing your order");
                            string readin = Console.ReadLine();
                            return MenuType.AddItemsToOrder;

                        }
                        else
                        {
                            Console.WriteLine("Enter a More specific name or check that the store exists");
                            Console.WriteLine("press enter to continue...");
                            Console.ReadLine();
                        }
                    
                    return MenuType.AddOrderMenu;
                case "2":
                    return MenuType.AddItemsToOrder;
                case "3":
                    return MenuType.ShowOrders;
                case "4":
                    _Orders.Customer = SingletonCustomer.Customer.Id;
                    _OrderBL.AddOrders(_Orders);
                    SingletonOrder.Order = _Orders;
                    Console.WriteLine("Orders has been added successfully");
                    Console.WriteLine("Press enter to continue..");
                    Console.ReadLine();
                    //SingletonStore.store.Name = null;
                    //_Orderss.Quantity="";
                    return MenuType.AddOrderMenu;

                case "0":
                    return MenuType.OrdersMenu;
                default:
                    Console.WriteLine(" Enter a Valid option ");
                    Console.WriteLine("press enter to continue...");
                    Console.ReadLine();
                    return MenuType.AddOrderMenu;
            }
        }
    }
}