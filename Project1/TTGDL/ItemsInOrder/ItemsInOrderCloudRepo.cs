using System.Collections.Generic;
using System.Linq;
using TTGModel;


namespace TTGDL
{
    public class ItemsInOrderCloudRepo : IItemsInOrderRepo
    {
        private database1Context _context;

        public ItemsInOrderCloudRepo(database1Context p_context)
        {
            _context = p_context;
        }

        public ItemsInOrder AddItemInOrder(ItemsInOrder p_items)
        {
            //method syntax
            _context.ItemsInOrders.Add(p_items);
      
            _context.SaveChanges();
            return p_items;
        }


        public List<ItemsInOrder> GetAllItemsInOrder()
        {
            //method syntax
            return _context.ItemsInOrders.ToList();
        }

        public List<ItemsInOrder> GetAllItemsInOrder(Orders p_order)
        {
            //method syntax
            return _context.ItemsInOrders
            .Where(item => item.OrderId == p_order.Id)
            .Select(ItemsInOrder =>
                new ItemsInOrder()
                {
                    OrderId = ItemsInOrder.OrderId,
                    LineItemId = ItemsInOrder.LineItemId,
                    Quantity = ItemsInOrder.Quantity
                }

            ).ToList();
        }


        // public List<Model.LineItem> GetLineItemsList(int p_storeId)
        // {
        //     return _context.LineItems
        //     .Where(item => item.Store == p_storeId)
        //     .Select(item =>
        //         new Model.LineItem()
        //         {
        //             ProductNavigation = new Model.Product()
        //             {
        //                 Name = item.ProductNavigation.Name,
        //                 Price = item.ProductNavigation.Price,
        //                 Description = item.ProductNavigation.Description,
        //                 Catagory = item.ProductNavigation.Catagory,
        //                 Id = item.ProductNavigation.Id
        //             },
        //             Quantity = item.Quantity,
        //             Id = item.Id,
        //             StoreFrontId = item.StorefrontId
        //         }
        //     ).ToList();
        // }
    }
}