using System.Collections.Generic;
using TTGModel;

namespace TTGBL
{
    public interface IItemsInOrderBL
    {
        /// <summary>
        /// this will return a list of ItemsInOrders from the database
        /// </summary>
        /// <returns></returns>
        List<ItemsInOrder> GetAllItemsInOrders();

        /// <summary>
        /// adds a new ItemsInOrder to the database
        /// </summary>
        /// <param name="p_cust"></param>
        /// <returns></returns>
        ItemsInOrder AddItemsInOrder(ItemsInOrder _item);

        List<ItemsInOrder> GetAllItemsInOrder(Orders _order);

    }
}