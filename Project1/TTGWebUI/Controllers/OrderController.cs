using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTGBL;
using TTGWebUI.Models;
using TTGModel;

namespace TTGWebUI.Controllers
{
    public class OrderController : Controller
    {
        IOrderBL _orderBL;
        IStoreBL _storeBL;
        ILineItemBL _lineItemBL;
        IProductBL _productBL;
        IItemsInOrderBL _itemsInOrderBL;
        ICustomerBL _customerBL;
        private static List<LineItem> _currentOrder = new List<LineItem>();
        public OrderController(IOrderBL p_orderBL, IStoreBL p_storeBL, ILineItemBL p_lineItemBL, IProductBL p_productBL, IItemsInOrderBL p_itemsInOrderBL, ICustomerBL p_customerBL)
        {
            _orderBL = p_orderBL;
            _storeBL = p_storeBL;
            _lineItemBL = p_lineItemBL;
            _productBL = p_productBL;
            _itemsInOrderBL = p_itemsInOrderBL;
            _customerBL = p_customerBL;
        }
        // GET: OrderController

        public ActionResult Index()
        {
            List<ItemsInOrder> ListOfOrderItems = new List<ItemsInOrder>();
            //List<Orders> listOfOrders = _orderBL.GetAllCustomerOrders(SingletonCustomerVM.Customer);
            List<Orders> listOfOrders = _orderBL.GetAllOrders();
            //stores all orders for a given customer in a dictionary
            Dictionary<int, OrderVM> OrderDict = new Dictionary<int, OrderVM>();
            Dictionary<int, ItemInOrderVM> ItemsInOrderDict = new Dictionary<int, ItemInOrderVM>();
            Dictionary<int, ProductVM> OrderProductDict = new Dictionary<int, ProductVM>();
            Dictionary<int, StoreVM> OrderStoreDict = new Dictionary<int, StoreVM>();
            Dictionary<int, CustomerVM> OrderCustDict = new Dictionary<int, CustomerVM>();

            for (int i = 0; i < listOfOrders.Count; i++)
            {
                //add one order to odrerDict from ListOfOrders
                OrderDict.Add(i, new OrderVM(listOfOrders[i]));

                OrderStoreDict.Add(i, new StoreVM(_storeBL.GetStoreById(listOfOrders[i].StoreFront)));
                OrderCustDict.Add(i, new CustomerVM(_customerBL.GetMatchingCustomer(listOfOrders[i].Customer)));
                //get all ItemInOrder Objects with the OrderID = the order added to OrderDict
                //List<ItemsInOrder> 
                ListOfOrderItems = _itemsInOrderBL.GetAllItemsInOrder(listOfOrders[i]);
                //add each ItemInOrder obj in ListOfOrderItems to ItemsInOrderDict
                //this dictonary will contain all ItemInOrder objects for all orders because of this the key will be as follows
                // i*1000+j this to make usre the keys are unique and can be used to reference the order they belong to 

                for (int j = 0; j < ListOfOrderItems.Count; j++)
                {
                    int key = (i * 1000) + j;
                    ItemsInOrderDict.Add(key, new ItemInOrderVM(ListOfOrderItems[j]));

                    //for each ItemInOrder get Lineitem refrenced by the fkey in ItemsInOrder
                    LineItem LItem = _lineItemBL.GetMatchingLineItem(ListOfOrderItems[j].LineItemId);


                    //use the found LineItem LItem to find the referenced product
                    Product OrderProd = _productBL.GetProductByID(LItem.Product);

                    //add the product OrderProd into the dictionary OrderProductDict
                    //use the same key as ItemsInOrderDict
                    OrderProductDict.Add(key, new ProductVM(OrderProd));
                }

            }

            ViewData.Add("OrderDict", OrderDict);
            ViewData.Add("OrderStoreDict", OrderStoreDict);
            ViewData.Add("OrderCustDict", OrderCustDict);
            ViewData.Add("ItemsInOrderDict", ItemsInOrderDict);
            ViewData.Add("OrderProductDict", OrderProductDict);
            return View();
        }
        //-------------------------------------Create----------------------------------------
        // GET: CustomerController/Create
        [HttpGet]
        public IActionResult Create()
        {
            List<Store> ListOfStores = _storeBL.GetAllStores();
            List<StoreVM> StoreList = new List<StoreVM>();
            foreach (Store store in ListOfStores)
            {
                StoreList.Add(new StoreVM(store));
            }
            ViewBag.stores = StoreList;
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        public IActionResult Create(OrderVM order)
        {
            _orderBL.AddOrders(new Orders()
            {
                Customer = order.Customer,
                StoreFront = order.StoreFront,
                Total = 0
            });
            List<Orders> ListOfOrders = _orderBL.GetAllCustomerOrders(SingletonCustomerVM.Customer);
            Orders CurrentOrder = _orderBL.GetOrder(ListOfOrders[ListOfOrders.Count-1].Id);
            SingletonOrderVM.Order = CurrentOrder;
            List<LineItem> ListOfLineItems = _lineItemBL.GetAllLineItems(order.StoreFront);
            List<ProductVM> ProdList = new List<ProductVM>();
            List<LineItemVM> ItemList = new List<LineItemVM>();
            for (int i = 0; i < ListOfLineItems.Count; i++)
            {
                ProdList.Add(new ProductVM(_productBL.GetProductByID(ListOfLineItems[i].Product)));
                ItemList.Add(new LineItemVM(ListOfLineItems[i]));
            }
            
            SingletonOrderVM.ListOfLineItemsVM = ItemList;
            SingletonOrderVM.ListOfProductsVM = ProdList;

            return View("AddToOrder");
            //return View(new LineItemVM() { Store = p_storeId });
        }
        //------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult AddToOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToOrder(ItemInOrderVM item)
        {
            //add to a temporary list of ItemInOrder objects for each item added to order 
            SingletonOrderVM.ListOfItems.Add(new ItemsInOrder()
            {
                OrderId = item.OrderId,
                LineItemId = item.LineItemId,
                Quantity = item.Quantity    
            });
            //get the LineItem obj referenced in the ItemInOrder obj and add that lineItem to ListofLineItems to be used for display 
            LineItem NewItem = _lineItemBL.GetMatchingLineItem(item.LineItemId);
            SingletonOrderVM.ListOfLineItems.Add(NewItem);
            //get the product obj referenced in the LineItem obj and add that product to ListofProducts to be used for display
            Product NewProduct = _productBL.GetProductByID(_lineItemBL.GetMatchingLineItem(item.LineItemId).Product);
            SingletonOrderVM.ListOfProducts.Add(NewProduct);

            //update the quantity of the entered ItemInOrder
            //for all lineItems at the selected storefront
            for (int i=0; i < SingletonOrderVM.ListOfLineItemsVM.Count; i++) // (LineItemVM LItem in SingletonOrderVM.ListOfLineItemsVM)
            {
                //if the Id of the current lineItem matches the Lineitem Id in ItemInOrder object that waas added
                if(item.LineItemId == SingletonOrderVM.ListOfLineItemsVM[i].Id)
                {
                    //update the LineItem with a new quantity that is its current quantity - quantity in ItemInOrder obj
                    _lineItemBL.UpdateQuantity(SingletonOrderVM.ListOfLineItemsVM[i].Id, SingletonOrderVM.ListOfLineItemsVM[i].Quantity - item.Quantity);
                    //reasing the current lineItem with the new Quantity
                    SingletonOrderVM.ListOfLineItemsVM[i] = new LineItemVM(_lineItemBL.GetMatchingLineItem(SingletonOrderVM.ListOfLineItemsVM[i].Id));
                }

            }
            SingletonOrderVM.Total = (NewProduct.Price * item.Quantity);



            return RedirectToAction(nameof(AddToOrder));
        }
        //-----------------------------Checkout---------------------------------------
        [HttpGet]
        public ActionResult Checkout()
        {
            foreach(ItemsInOrder item in SingletonOrderVM.ListOfItems)
            {
                _itemsInOrderBL.AddItemsInOrder(item);
            }
            //SingletonOrderVM.Order.Id;
            return View("Index");
        }




    }





}
