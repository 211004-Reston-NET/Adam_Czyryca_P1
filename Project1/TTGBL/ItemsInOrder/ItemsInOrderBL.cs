using System.Collections.Generic;
using System.Linq;
using TTGDL;
using TTGModel;

namespace TTGBL
{
    public class ItemsInOrderBL : IItemsInOrderBL
    {
        //define an Interface object to allow usage of all classes inhireting that method
        private IItemsInOrderRepo _itemRepo;
        // this classes constructor
        public ItemsInOrderBL(IItemsInOrderRepo p_itemRepo)
        {
            _itemRepo = p_itemRepo;
        }



        public ItemsInOrder AddItemsInOrder(ItemsInOrder p_item)
        {
            return _itemRepo.AddItemInOrder(p_item);
        }

        public List<ItemsInOrder> GetAllItemsInOrder(Orders p_order)
        {
            return _itemRepo.GetAllItemsInOrder(p_order);
        }

        public List<ItemsInOrder> GetAllItemsInOrders()
        {
            List<ItemsInOrder> listOfItemsInOrders = _itemRepo.GetAllItemsInOrder();

            return listOfItemsInOrders;
        }

        // public List<ItemsInOrder> GetItemsInOrder(string p_name)
        // {
        //     List<ItemsInOrder> listOfItemsInOrder = _itemRepoGetAllItemsInOrder();

        //     //Select method will give a list of boolean if the condition was true/false
        //     //Where method will give the actual element itself based on some condition
        //     //ToList method will convert into List that our method currently needs to return.
        //     //ToLower will lowercase the string to make it not case sensitive
        //     return listOfItemsInOrder.Where(cust => cust.Name.ToLower().Contains(p_name.ToLower())).ToList();
        // }
    }
}