using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTGModel;

namespace TTGWebUI.Models
{
    public class SingletonOrderVM
    {
        public static Orders Order = new Orders();
        public static double Total= new double();
        public static Store Store = new Store();
        //----------------------------------populated in AddToOrder---------------------------------------
        public static List<LineItem> ListOfLineItems = new List<LineItem>();
        //------------------------------populated in Create-----------------------------------------------
        public static List<LineItemVM> ListOfLineItemsVM = new List<LineItemVM>();
        public static List<ProductVM> ListOfProductsVM = new List<ProductVM>();
        //------------------------------not currently used------------------------------------------------
        public static List<ItemInOrderVM> ListOfItemsVM = new List<ItemInOrderVM>();
        public static List<Product> ListOfProducts = new List<Product>();
        public static List<ItemsInOrder> ListOfItems = new List<ItemsInOrder>();
    }
}
