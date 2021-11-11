using TTGModel;

namespace TTGWebUI.Models
{
    public class ItemInOrderVM
    {

        public ItemInOrderVM()
        {

        }

        public ItemInOrderVM (ItemsInOrder p_item)
        {
            this.Id = p_item.Id;
            this.OrderId = p_item.OrderId;
            this.LineItemId= p_item.LineItemId;
            this.Quantity = p_item.Quantity;
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int LineItemId { get; set; }
        public int Quantity { get; set; }

    }
}
