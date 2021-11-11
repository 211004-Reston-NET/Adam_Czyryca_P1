using System;
using System.Collections.Generic;
using TTGBL;
using TTGModel;

namespace TTGUI
{
    public class CurrentLineItem : IMenu
    {
        private ILineItemBL _lineBL;
        private IProductBL _prodBL;
        private IStoreBL _storeBL;
        LineItem FoundLineItem;
        public CurrentLineItem(ILineItemBL p_lineBL, IProductBL p_prodBL, IStoreBL p_storeBL)
        {
            _lineBL = p_lineBL;
            _prodBL = p_prodBL;
            _storeBL = p_storeBL;
        }
        public void Menu()
        {
            FoundLineItem = _lineBL.GetMatchingLineItem(ShowLineItems._findlineItemName);
            Product prodPrint = _prodBL.GetProductByID(FoundLineItem.Product);
            Store storePrint = _storeBL.GetStoreById(FoundLineItem.Store);
            //Console.WriteLine(SingletonLineItem.LineItem.Name);
            //Console.WriteLine("search result");

            Console.WriteLine(
                "search result\n" +
                "-------------------------\n" +
                $"LineItem_ID: {FoundLineItem.Id}\n" +
                $"Store: {storePrint.Name}\n" +
                $"Amount in stock: {FoundLineItem.Quantity}\n" +
                $"{prodPrint.ToString()}\n" +
                "-------------------------\n"
            );
            Console.WriteLine("[1] - update stock of this LineItem");
            Console.WriteLine("[0] - Go back");
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("what is the new stock of this item");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    _lineBL.UpdateQuantity(FoundLineItem.Id, amount);
                    return MenuType.CurrentLineItem;
                case "0":
                    //SingletonLineItem.LineItem.Name = "";
                    return MenuType.ShowLineItems;
                default:
                    Console.WriteLine("Enter a valid response");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    return MenuType.CurrentLineItem;
            }
        }
    }
}