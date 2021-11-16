using System;
using TTGModel;
using TTGBL;
using System.Collections.Generic;

namespace TTGUI
{
    public class test : IMenu
    {
        IOrderBL _orderBL;
        IStoreBL _storeBL;
        ILineItemBL _lineItemBL;
        IProductBL _productBL;
        IItemsInOrderBL _itemsInOrderBL;
        private static List<LineItem> _currentOrder = new List<LineItem>();
        public test(IOrderBL p_orderBL, IStoreBL p_storeBL, ILineItemBL p_lineItemBL, IProductBL p_productBL, IItemsInOrderBL p_itemsInOrderBL)
        {
            _orderBL = p_orderBL;
            _storeBL = p_storeBL;
            _lineItemBL = p_lineItemBL;
            _productBL = p_productBL;
            _itemsInOrderBL = p_itemsInOrderBL;
        }
        public void Menu()
        {
            List<ItemsInOrder> ListOfOrderItems = new List<ItemsInOrder>();
            List<Orders> listOfOrders = _orderBL.GetAllCustomerOrders(SingletonCustomer.Customer);
            //stores all orders for a given customer in a dictionary
            Dictionary<int, Orders> OrderDict = new Dictionary<int, Orders>();
            Dictionary<int, ItemsInOrder> ItemsInOrderDict = new Dictionary<int, ItemsInOrder>();
            Dictionary<int, Product> OrderProductDict = new Dictionary<int, Product>();

            for (int i = 0; i < listOfOrders.Count; i++)
            {
                //add one order to odrerDict from ListOfOrders
                OrderDict.Add(i, listOfOrders[i]);

                //get all ItemInOrder Objects with the OrderID = the order added to OrderDict
                //List<ItemsInOrder> 
                ListOfOrderItems = _itemsInOrderBL.GetAllItemsInOrder(listOfOrders[i]);
                //add each ItemInOrder obj in ListOfOrderItems to ItemsInOrderDict
                //this dictonary will contain all ItemInOrder objects for all orders because of this the key will be as follows
                // i*1000+j this to make usre the keys are unique and can be used to reference the order they belong to 
               
                for (int j = 0; j < ListOfOrderItems.Count; j++)
                {
                    int key = (i * 1000) + j;
                    ItemsInOrderDict.Add(key, ListOfOrderItems[j]);

                    //for each ItemInOrder get Lineitem refrenced by the fkey in ItemsInOrder
                    LineItem LItem = _lineItemBL.GetMatchingLineItem(ListOfOrderItems[j].LineItemId);


                    //use the found LineItem LItem to find the referenced product
                    Product OrderProd = _productBL.GetProductByID(LItem.Product);

                    //add the product OrderProd into the dictionary OrderProductDict
                    //use the same key as ItemsInOrderDict
                    OrderProductDict.Add(key, OrderProd);
                }

            }
            Console.WriteLine(
            "____________________________\n" +
            "test\n" +
            $"Name - {SingletonCustomer.Customer.Name}\n" +
            $"listOfOrders -{listOfOrders.Count}\n" +
            $"ordDict -{OrderDict.Count}\n" +
            $"ListOfOrderItems -{ListOfOrderItems.Count}\n" +
            $"ItemsInOrderDict -{ItemsInOrderDict.Count}\n" +
            $"OrderProductDict -{OrderProductDict.Count}\n" +
            "______________________________\n"
            );





        }

        public MenuType Navigation()
        {
            throw new NotImplementedException();
        }
    }
}