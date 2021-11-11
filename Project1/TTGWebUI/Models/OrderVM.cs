using TTGModel;

namespace TTGWebUI.Models
{
    public class OrderVM
    {
        
        public OrderVM()
        {

        }

        public OrderVM(Orders p_order )
        {
            this.Id = p_order.Id;
            this.StoreFront = p_order.StoreFront;
            this.Customer = p_order.Customer;
            this.Total = p_order.Total;
        }


        public int Id { get; set; }
        public int StoreFront { get; set; }
        public int Customer { get; set; }
        public double Total { get; set; }

    }
}
