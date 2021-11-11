using System.Collections.Generic;
using System.Linq;
using TTGModel;


namespace TTGDL
{
    public class OrderCloudRepo : IOrdersRepository
    {
        private database1Context _context;

        public OrderCloudRepo(database1Context p_context)
        {
            _context = p_context;
        }
        public Orders AddOrder(Orders p_order)
        {
            _context.Orders.Add(p_order);
            
            _context.SaveChanges();
            return p_order;
        }

        public List<Orders> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public List<Orders> GetAllCustomerOrders(Customer p_cust)
        {
            //method syntax
            return _context.Orders
            .Where(ord=> ord.Customer == p_cust.Id)
            .Select(order =>
                new Orders()
                {
                    Id = order.Id,
                    StoreFront = order.StoreFront,
                    Customer = order.Customer,
                    Total = order.Total
                }

            ).ToList();
        }

        public Orders GetOrder(int p_orderId)
        {
            var result = _context.Orders
                .FirstOrDefault<Orders>(_order =>
                    _order.Id == p_orderId);
            return new Orders()
            {
                Id = result.Id,
                StoreFront= result.StoreFront,
                Customer = result.Customer,
                Total = result.Total
            };
        }

        public int GetOrderId (Orders p_order)
        {
            Orders order =GetOrder(p_order.Id);
            return order.Id;
        }
    }
}