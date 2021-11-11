using System.Collections.Generic;
using TTGModel;
namespace TTGDL
{
    public interface IItemsInOrderRepo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ItemsInOrder> GetAllItemsInOrder();

        /// <summary>
        /// adds line item with refence to the product and string 
        /// </summary>
        /// <param name="p_LineItem"></param>
        /// <param name="ProdName"></param>
        /// <param name="StoreName"></param>
        /// <returns></returns>
        ItemsInOrder AddItemInOrder(ItemsInOrder p_items);

        List<ItemsInOrder> GetAllItemsInOrder(Orders _order);
    }
}