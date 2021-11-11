using System;
using System.Collections.Generic;
using TTGBL;
using TTGModel;

namespace TTGUI
{
    public class ShowLineItems : IMenu
    {
        private ILineItemBL _lineItemBL;
        private IProductBL _prodBL;
        private IStoreBL _storeBL;
        public static int _findlineItemName;
        public ShowLineItems(ILineItemBL p_lineItemBL,IProductBL p_prodBL, IStoreBL p_storeBL)
        {
            _lineItemBL = p_lineItemBL;
            _prodBL = p_prodBL;
            _storeBL = p_storeBL;
        }
        public void Menu()
        {
            Console.WriteLine("Registered LineItem");
            List<LineItem> ListOfLineItem = _lineItemBL.GetAllLineItems();
            foreach (LineItem LineItem in ListOfLineItem)
            {
                Product prodPrint = _prodBL.GetProductByID(LineItem.Product);
                Store storePrint = _storeBL.GetStoreById(LineItem.Store);
                Console.WriteLine(
                    "-------------------------\n" +
                    $"LineItem_ID: {LineItem.Id}\n" +
                    $"Store: {storePrint.Name}\n" +
                    $"Amount in stock: {LineItem.Quantity}\n" +
                    $"{prodPrint.ToString()}\n" +
                    "-------------------------\n"
                );
            }
            Console.WriteLine("[1] - search for LineItem");
            Console.WriteLine("[0] - Go back");
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("Enter the Id for the LineItem you want to find");
                    _findlineItemName = Convert.ToInt32(Console.ReadLine());
                    return MenuType.CurrentLineItem;
                case "0":
                    return MenuType.LineItemMenu;
                default:
                    Console.WriteLine("Enter a valid response");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    return MenuType.ShowLineItems;
            }
        }
    }
}