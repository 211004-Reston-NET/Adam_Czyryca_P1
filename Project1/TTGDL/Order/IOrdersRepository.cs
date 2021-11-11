using System.Collections.Generic;
using TTGModel;

namespace TTGDL
{
    public interface IOrdersRepository 
    {
        /// <summary>
        /// get all the orders in the DB and retern as a list
        /// </summary>
        /// <returns></returns>
        List<Orders> GetAllOrders();

        /// <summary>
        /// add a new customer obj to the db 
        /// </summary>
        /// <param name="cust"></param>
        /// <returns></returns>
        Orders AddOrder(Orders cust);

        /// <summary>
        /// will return an order with the matching id
        /// </summary>
        /// <param name="p_orderId"></param>
        /// <returns></returns>
        Orders GetOrder(int p_orderId);

        int GetOrderId(Orders p_order);

        List<Orders> GetAllCustomerOrders(Customer _cust);
    }
}