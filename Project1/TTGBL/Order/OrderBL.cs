using System.Collections.Generic;
using TTGDL;
using Model =TTGModel;

namespace TTGBL
{
    public class OrderBL : IOrderBL
    {
        public IOrdersRepository _orderRepo;

        public OrderBL(IOrdersRepository p_order)
        {
            _orderRepo =p_order;
        }


        public Model.Orders AddOrders(Model.Orders p_order)
        {
            return _orderRepo.AddOrder(p_order);
        }

        public List<Model.Orders> GetAllOrders()
        {
            List<Model.Orders> listOfOrders = _orderRepo.GetAllOrders();
            
            return listOfOrders;
        }

        public Model.Orders GetOrder(int p_orderId)
        {
            return _orderRepo.GetOrder(p_orderId);
        }

        public int GetOrderId(Model.Orders p_order)
        {
            return _orderRepo.GetOrderId(p_order);
        }

        public List<Model.Orders> GetAllCustomerOrders(Model.Customer p_cust)
        {
            return _orderRepo.GetAllCustomerOrders(p_cust);
        }

        public List<Model.Orders> GetAllCustomerOrders(int p_custId)
        {
            return _orderRepo.GetAllCustomerOrders(p_custId);
        }


        public List<Model.Orders> GetAllStoreOrders(int p_storeId)
        {
            return _orderRepo.GetAllCustomerOrders(p_storeId);
        }
        public void UpdateTotal(int p_orderID, double p_newTotal)
        {
             _orderRepo.UpdateTotal(p_orderID, p_newTotal);
        }
    }
}