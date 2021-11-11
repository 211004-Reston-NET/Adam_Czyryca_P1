using System;
using System.Collections.Generic;
using TTGBL;
using TTGModel;

namespace TTGUI
{
    public class ShowOrders : IMenu
    {
        private IOrderBL _orderBL;
        private IStoreBL _storeBL;
        private IItemsInOrderBL _itemInOrderBL;
        private ILineItemBL _lineItemBL;
        private IProductBL _prodBL;
        public ShowOrders(IOrderBL p_orderBL, IStoreBL p_storeBL, IItemsInOrderBL p_itemInOrderBL, ILineItemBL p_lineItemBL, IProductBL p_prodBL)
        {
            _orderBL = p_orderBL;
            _storeBL = p_storeBL;
            _itemInOrderBL = p_itemInOrderBL;
            _lineItemBL = p_lineItemBL;
            _prodBL = p_prodBL;
        }
        public void Menu()
        {
            Console.WriteLine(
                    "-------------------------\n" +
                    $"{SingletonCustomer.Customer.Name}'s Order History\n" +
                    "-------------------------\n"
                    );
            //for each order belonging to the passed customer
            List<Orders> ListOfOrders = _orderBL.GetAllCustomerOrders(SingletonCustomer.Customer);
            foreach (Orders Order in ListOfOrders)
            {  
                //this should always be true due to how the list was generated
                if (Order.Customer == SingletonCustomer.Customer.Id)
                {
                    Console.WriteLine(
                    "-------------------------\n" +
                    $"OrderID: {Order.Id}\n"+
                    $"store: {(_storeBL.GetStoreById(Order.StoreFront).Name)}\n"
                    );
                    //get all ItemsInOrder obj containing the id of the current order 
                    List<ItemsInOrder> ListOfItemsInOrder = _itemInOrderBL.GetAllItemsInOrder(Order);
                    
                    foreach(ItemsInOrder orderItem in ListOfItemsInOrder )
                    {
                        //get the product from lineItem from orderItem
                        LineItem LineItemToPrint = _lineItemBL.GetMatchingLineItem(orderItem.LineItemId);
                        Product ProdToPrint = _prodBL.GetProductByID(LineItemToPrint.Product);
                        Console.WriteLine(
                        $"{orderItem.Quantity} {ProdToPrint.Name} price:{orderItem.Quantity*ProdToPrint.Price}\n" 
                        );
                    }
                    //order total
                    Console.WriteLine(
                    $"total: {Order.Total}\n"+
                    "-------------------------\n"
                    );
                }

            }
            //Console.WriteLine("[1] - select Order to add items to");
            Console.WriteLine("[0] - Go back");
        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("Enter the Id of the Order to edit");
                    int _enteredOrderID = Convert.ToInt32(Console.ReadLine());
                    SingletonOrder.Order = _orderBL.GetOrder(_enteredOrderID);
                    SingletonStore.store = _storeBL.GetStoreById(SingletonOrder.Order.StoreFront);
                    Console.WriteLine($"{SingletonOrder.Order}\n has been updated to the current order");
                    Console.ReadLine();

                    return MenuType.ShowOrders;
                case "0":
                    if(SingletonUser.User==1)
                    {
                        return MenuType.OrdersMenu;
                    }
                    return MenuType.TestingMenu;
                default:
                    Console.WriteLine("Enter a valid response");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    return MenuType.ShowOrders;
            }
        }
    }
}