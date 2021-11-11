using System.Collections.Generic;
using TTGModel;
namespace TTGDL
{
    public interface ICustRepository
    {
        /// <summary>
        /// will return a list of customer objects from the database
        /// </summary>
        /// <returns></returns>
        List<Customer> GetAllCustomers();

        /// <summary>
        /// will add a customer object to the database
        /// </summary>
        /// <param name="cust"></param>
        /// <returns></returns>
        Customer  AddCustomer(Customer cust);

        /// <summary>
        /// will return a single customer obj with name and email matching those passed in 
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