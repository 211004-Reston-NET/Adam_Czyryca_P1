using System;
using TTGModel;
using TTGBL;
using System.Collections.Generic;

namespace TTGUI
{
    public class AddLineItemsMenu : IMenu
    {

        private static LineItem _LineItem = new LineItem();
        private ILineItemBL _LineItemsBL;
        private IProductBL _prodBL;

        private IStoreBL _storeBL;

        public AddLineItemsMenu(ILineItemBL p_LineItemsBL, IProductBL p_prodBL, IStoreBL p_storeBL)
        {
            _LineItemsBL = p_LineItemsBL;
            _prodBL = p_prodBL;
            _storeBL = p_storeBL;
        }
        public void Menu()
        {
            Console.WriteLine(
            "____________________________\n" +
            "Add LineItem Menu\n" +
            $"Product - {SingletonProduct.product.Name}\n" +
            $"Quantity -{_LineItem.Quantity}\n" +
            $"Store - {SingletonStore.store.Name}\n" +
            "[1] - Input value for product\n" +
            "[2] - Input value for Quantity\n" +
            "[3] - Input value for store\n" +
            "[4] - Submit Information\n" +
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

                    Console.Write("Product Name: ");
                    SingletonProduct.product.Name = Console.ReadLine();
                    //SingletonProduct.product.Name = test.ToString();
                    List<Product> FoundProd = new List<Product>();
                    FoundProd = _prodBL.GetProduct(SingletonProduct.product.Name);
                    Console.WriteLine($"Is this correct [Y] [N]: {FoundProd[0].Name}");
                    String result = Console.ReadLine();
                    if (result.ToUpper() == "Y")
                    {
                        _LineItem.Product = FoundProd[0].Id;
                        Console.WriteLine(FoundProd[0]);
                        Console.ReadLine();
                        SingletonProduct.product.Name = FoundProd[0].Name;
                    }
                    else
                    {
                        Console.WriteLine("Enter a More specific name or check that the Product exists");
                        Console.WriteLine("press enter to continue...");
                        Console.ReadLine();
                    }


                    return MenuType.AddLineItemsMenu;

                case "2":
                    Console.Write("Quantity: ");
                    _LineItem.Quantity = Convert.ToInt32(Console.ReadLine());
                    return MenuType.AddLineItemsMenu;
                case "3":

                    Console.Write("Store Name: ");
                    SingletonStore.store.Name = Console.ReadLine();
                    List<Store> FoundStore = new List<Store>();
                    FoundStore = _storeBL.GetStore(SingletonStore.store.Name);
                    Console.WriteLine($"Is this correct [Y] [N]: {FoundStore[0].Name}");
                    String result2 = Console.ReadLine();
                    if (result2.ToUpper() == "Y")
                    {
                        _LineItem.Store = FoundStore[0].Id;

                        SingletonStore.store.Name = FoundStore[0].Name;

                    }
                    else
                    {
                        Console.WriteLine("Enter a More specific name or check that the store exists");
                        Console.WriteLine("press enter to continue...");
                        Console.ReadLine();
                    }


                    return MenuType.AddLineItemsMenu;
                case "4":
                    _LineItemsBL.AddLineItem(_LineItem);
                    Console.WriteLine("LineItems has been added successfully");
                    Console.WriteLine("Press enter to continue..");
                    Console.ReadLine();
                    SingletonStore.store.Name = null;
                    //_LineItems.Product="";
                    //_LineItems.Quantity="";
                    return MenuType.AddLineItemsMenu;

                case "0":
                    return MenuType.LineItemMenu;
                default:
                    Console.WriteLine(" Enter a Valid option ");
                    return MenuType.CustomerMenu;
            }
        }
    }
}