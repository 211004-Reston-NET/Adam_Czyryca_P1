using System;
using System.Collections.Generic;
using TTGBL;
using TTGModel;

namespace TTGUI
{
    public class AddItemsToOrder : IMenu

    {
        
        private static List<ItemsInOrder> ListOfItemsInOrder = new List<ItemsInOrder>();
        private static List<Orders> ListOfOrders = new List<Orders>();
        private IItemsInOrderBL _ItemsInOrderBL;
        private ILineItemBL _lineItemBL;
        private IOrderBL _orderBL;

        private IProductBL _prodBL;
        private ICustomerBL _custBL;

        public AddItemsToOrder(IItemsInOrderBL p_ItemsInOrderBL, ILineItemBL p_lineItemBL, IOrderBL p_orderBL, IProductBL p_prodBL, ICustomerBL p_custBL)//IprodBL
        {
            _ItemsInOrderBL = p_ItemsInOrderBL;
            _lineItemBL = p_lineItemBL;
            _orderBL = p_orderBL;
            _prodBL = p_prodBL;
            _custBL = p_custBL;
        }

        public void Menu()
        {
            Console.WriteLine("Add Products To an Order ");
            List<LineItem> ListOfLineItems = _lineItemBL.GetAllLineItems(SingletonStore.store.Id);
            //_prodBL.GetProductByID();

            foreach (LineItem item in ListOfLineItems)
            {
                Product prodPrint = new Product();
                prodPrint = _prodBL.GetProductByID(item.Product);
                Console.WriteLine(
                "------------------------\n" +
                $"ID:{item.Id}\n" +
                $"In Stock:{item.Quantity}\n" +
                $"{prodPrint.ToString()}\n" +
                "------------------------\n"
                );

            }
            Console.WriteLine(
                "------------------------\n" +
                $"Order Total: {SingletonOrder.Order.Total} \n" +
                "------------------------\n" +
                "[1] - Add product\n" +
                "[2] - Cancel order\n" +
                "[3] - Checkout\n" +
                "[0] - Go back\n" +
                "------------------------\n"
            );

        }

        public MenuType Navigation()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1": // add product 
                    Console.WriteLine("Enter the name of a Product to add it to an order");
                    Console.Write("Product Name: ");
                    //set the product name entered by the user to the singleton customer obj
                    SingletonProduct.product.Name = Console.ReadLine();

                    List<Orders> ListOfOrders = new List<Orders>();
                    List<LineItem> ListOfLineItems = new List<LineItem>();
                    List<Product> ListOfProducts = new List<Product>();
                    //get all products that are a posible match to the entered string
                    List<Product> TempListOfProducts = _prodBL.GetProduct(SingletonProduct.product.Name);
                    ListOfLineItems = _lineItemBL.GetAllLineItems(SingletonStore.store.Id);
                    //aditonal checking to ensure the products retreved the store has an assosiated lineitem
                    foreach (Product prod in TempListOfProducts)
                    {
                        foreach (LineItem item in ListOfLineItems)
                        {
                           if(prod.Id == item.Product) 
                           {
                               ListOfProducts.Add(prod);
                           }
                        }
                    }

                    //ListOfLineItems = _lineItemBL.GetAllLineItems();
                    int prod_id;
                    //return the name of the first product found from GetProduct
                    //and ask the user if that is the product they wanted
                    Console.WriteLine($"Add {ListOfProducts[0].Name} to Order [Y] [N]?");
                    String result = Console.ReadLine();

                    //the correct product was found
                    if (result.ToUpper() == "Y")
                    {
                        prod_id = ListOfProducts[0].Id;
                        foreach (LineItem item in ListOfLineItems)
                        {
                            //if there is a lineItem at the selected store with the selected product
                            if ((item.Store == SingletonStore.store.Id) && (item.Product == prod_id))
                            {
                                //how many of selected product to add to the order
                                Console.WriteLine("How Many?");
                                //Boolean loop = true;
                                int amount;
                                //loop will compile the list of lineItems to add to the order 
                                // and check the stock to ensure the placed order is valid

                                Console.Write("Amount: ");
                                try
                                {
                                    amount = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Amount must be an integer!");
                                    Console.WriteLine("Press enter to continue...");
                                    Console.ReadLine();
                                    break;
                                }


                                //desired quantity is avalible
                                if (amount <= item.Quantity)
                                {
                                    ItemsInOrder ItemAdd = new ItemsInOrder();
                                    //update the ItemInOrder obj ItemAdd with the Lineitem id and the quantity
                                    ItemAdd.LineItemId = item.Id;
                                    ItemAdd.Quantity = amount;
                                    // Console.WriteLine(ItemAdd.LineItemId);
                                    // Console.WriteLine(ItemAdd.Quantity);
                                    // Console.ReadLine();
                                    //compile a list of lineitems to add to the order 
                                    ListOfItemsInOrder.Add(ItemAdd);
                                    //ItemAdd.OrderId = SingletonOrder.Order.Id;
                                    SingletonOrder.Order.Total += (ListOfProducts[0].Price * amount);
                                    //_ItemsInOrderBL.AddItemsInOrder(ItemAdd);
                                    //take the entered amount and subtract it from the current quanity then update 
                                    int setQuantity = item.Quantity - amount;

                                    //_lineItemBL.UpdateQuantity(item.Id, setQuantity);
                                    foreach (ItemsInOrder ItemPrint in ListOfItemsInOrder)
                                    {
                                        Console.WriteLine(ItemPrint.ToString());
                                    }
                                    //  loop = false;
                                    Console.WriteLine("item added to order");
                                    Console.WriteLine("Press enter to continue...");
                                    Console.ReadLine();
                                }
                                //add zero of the product to the order
                                else if (amount == 0)
                                {
                                    Console.WriteLine("item not added");
                                    Console.WriteLine("Press enter to continue...");
                                    Console.ReadLine();
                                }
                                //desired quantity is not avalible
                                else
                                {
                                    Console.WriteLine("Not enough in stock!\n  Choose fewer to add to your order\n  Chose zero not to add to order");
                                    Console.WriteLine("Press enter to continue...");
                                    Console.ReadLine();
                                }

                            }
                        }
                    }
                    //the correct product was not found
                    else if (result.ToUpper() == "N")
                    {
                        Console.WriteLine("Enter a more spesific name or check that the product exists");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("please enter Y for Yes or N for No");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }

                    //SingletonProduct.product.Name = Console.ReadLine();
                    return MenuType.AddItemsToOrder;
                case "2":
                    return MenuType.AddItemsToOrder;
                case "3": // checkout
                    Console.WriteLine("Finish adding products and move to check out [Y] or [N]");
                    String goToCheckOut = Console.ReadLine();

                    if (goToCheckOut.ToUpper() == "Y")
                    {
                        SingletonOrder.Order.Customer = SingletonCustomer.Customer.Id;
                        SingletonOrder.Order.StoreFront = SingletonStore.store.Id;
                        _orderBL.AddOrders(SingletonOrder.Order);

                        //get the order id of the order created on the previous line
                        ListOfOrders = _orderBL.GetAllCustomerOrders(SingletonCustomer.Customer);
                        for (int i = 0; i < ListOfOrders.Count; i++)
                        {
                            //if i is at the last element(most recently added) of the list
                            if (i == ListOfOrders.Count - 1)
                            {
                                //set the found orderid to the order reference in each item in ListOfItemsInOrder
                                //then add them to the db 
                                foreach (ItemsInOrder itemIn in ListOfItemsInOrder)
                                {
                                    itemIn.OrderId = ListOfOrders[i].Id;
                                    _ItemsInOrderBL.AddItemsInOrder(itemIn);
                                }

                                Console.WriteLine("Your Order has been Succesfuly added");
                                Console.WriteLine("Press enter to continue...");
                                Console.ReadLine();

                            }
                        }

                        return MenuType.ShowOrders;
                    }
                    else if (goToCheckOut.ToUpper() == "N")
                    {
                        Console.WriteLine("You will return to the Add products to order menu");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("please enter Y for Yes or N for No");
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                    return MenuType.AddItemsToOrder;
                case "0":
                    return MenuType.ProductMenu;
                default:
                    Console.WriteLine("Enter a valid response");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    return MenuType.AddItemsToOrder;
            }
        }
    }
}