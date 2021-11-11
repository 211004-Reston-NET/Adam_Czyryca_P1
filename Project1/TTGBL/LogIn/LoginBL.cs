using System;
using System.Collections.Generic;
using System.Linq;
using TTGDL;
using Model = TTGModel;

namespace TTGBL
{
    public class LogInBL : ILogInBL
    {
        private ICustRepository _custRepo;

        public LogInBL(ICustRepository p_custRepo)
        {
            _custRepo = p_custRepo;
        }

        public Boolean VerifyCustomerID(string p_custName, string p_custEmailPhone)
        {
            List<Model.Customer> listOfCustomer = _custRepo.GetAllCustomers();

            List<Model.Customer> match = (listOfCustomer
                .Where(cust => cust.Name.ToLower().Contains(p_custName.ToLower())).ToList())
                .Where(cust => cust.EmailPhone.Contains(p_custEmailPhone)).ToList();

            if ((match[0].Name).ToLower() == (p_custName).ToLower() && match[0].EmailPhone == p_custEmailPhone)
            {
                return true;
            }
            return false;
        }
    }
}