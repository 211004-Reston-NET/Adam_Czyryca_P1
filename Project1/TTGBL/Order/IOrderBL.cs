using System.Collections.Generic;
using TTGModel;

namespace TTGBL
{
    public interface IOrderBL
    {
        /// <summary>
        /// this will return a list of orders from the database
        /// </summary>
        /// <returns></returns>
        List<Orders> GetAllOrders();

        /// <summary>
        /// adds a new Order to the database
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns></returns>
        Orders AddOrders(Orders p_order);

        /// <summary>
        /// finds a specific order in the database
        /// </summary>
        /// <param name="p_orderId"></param>
        /// <returns></returns>
        Orders GetOrder(int p_orderId);

        /// <summary>
        /// updates the total for the order with a matching Id
        /// </summary>
        /// <param name="p_orderID"></param>
        /// <param name="p_newTotal"></param>
        void UpdateTotal(int _orderID, int _newTotal);



        int GetOrderId(Orders p_order);

        List<Orders> GetAllCustomerOrders(Customer _cust);
    }

}