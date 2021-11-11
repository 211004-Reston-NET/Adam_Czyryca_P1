using System.Collections.Generic;
using TTGModel;

namespace TTGBL
{
    public interface ICustomerBL
    {
        /// <summary>
        /// this will return a list of customers from the database
        /// </summary>
        /// <returns></returns>
        List<Customer> GetAllCustomers();

        /// <summary>
        /// adds a new customer to the database
        /// </summary>
        /// <param name="p_cust"></param>
        /// <returns></returns>
        Customer AddCustomer(Customer p_cust);

        /// <summary>
        /// will return a list of matching customers
        /// </summary>
        /// <param name="p_custName"></param>
        /// <returns></returns>
        List<Customer> GetCustomer(string p_custName);

        /// <summary>
        /// will return one customer obj that contains data matching the parameters 
        /// </summary>
        /// <param name="_custName"></param>
        /// <param name="_emailPhone"></param>
        /// <returns></returns>
        Customer GetMatchingCustomer(string _custName, string _emailPhone);

        /// <summary>
        ///  will return a single customer obj with an Id matching the passed int
        /// </summary>
        /// <param name="_custID"></param>
        /// <returns></returns>
        Customer GetMatchingCustomer(int _custID);

        /// <summary>
        /// removes the passed customer onj from the database
        /// </summary>
        /// <param name="_cust">cust to delete</param>
        /// <returns>deleted cust</returns>
        Customer DeleteCustomer(Customer _cust);
    }
}