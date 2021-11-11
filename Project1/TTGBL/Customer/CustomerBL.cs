using System.Collections.Generic;
using System.Linq;
using TTGDL;
using TTGModel;

namespace TTGBL
{
    public class CustomerBL : ICustomerBL
    {
        //define an Interface object to allow usage of all classes inhireting that method
        private ICustRepository _custRepo;
        // this classes constructor
        public CustomerBL(ICustRepository p_custRepo)
        {
            _custRepo=p_custRepo;
        }

        public Customer AddCustomer(Customer p_cust)
        {
           return _custRepo.AddCustomer(p_cust);
        }

        public Customer DeleteCustomer(Customer p_cust)
        {
            return _custRepo.DeleteCustomer(p_cust);
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> listOfCustomers = _custRepo.GetAllCustomers();
            for (int i = 0; i < listOfCustomers.Count; i++)
            {
                listOfCustomers[i].Name = listOfCustomers[i].Name.ToUpper();
            }
            return listOfCustomers;
        }

        public List<Customer> GetCustomer(string p_name)
        {
            List<Customer> listOfCustomer = _custRepo.GetAllCustomers();
            
            //Select method will give a list of boolean if the condition was true/false
            //Where method will give the actual element itself based on some condition
            //ToList method will convert into List that our method currently needs to return.
            //ToLower will lowercase the string to make it not case sensitive
            return listOfCustomer.Where(cust => cust.Name.ToLower().Contains(p_name.ToLower())).ToList();
        }

        public Customer GetMatchingCustomer(string p_custName, string p_emailPhone)
        {
            return _custRepo.GetMatchingCustomer(p_custName, p_emailPhone);
        }

        public Customer GetMatchingCustomer(int p_custID)
        {
            return _custRepo.GetMatchingCustomer(p_custID);
        }
    }
}