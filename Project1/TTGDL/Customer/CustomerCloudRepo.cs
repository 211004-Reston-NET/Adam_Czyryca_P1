using System;
using System.Collections.Generic;
using System.Linq;
using TTGModel;

namespace TTGDL
{
    public class CustomerCloudRepo : ICustRepository
    {
        private database1Context _context;

        public CustomerCloudRepo(database1Context p_context)
        {
            _context = p_context;
        }

        
        public Customer AddCustomer(Customer p_cust)
        {
            _context.Customers.Add(p_cust);
        
            _context.SaveChanges();
            return p_cust;
        }

        public Customer DeleteCustomer(Customer p_cust)
        {
            _context.Customers.Remove(p_cust);
            _context.SaveChanges();
            return p_cust;
        }

        public List<Customer> GetAllCustomers()
        {
            //method syntax
            return _context.Customers.Select(cust =>
                new Customer()
                {
                    Id = cust.Id,
                    Name = cust.Name,
                    Address = cust.Address,
                    EmailPhone = cust.EmailPhone

                }

            ).ToList();

            //query syntax 
            // var result = (from cust in _context.Customers
            //                 select cust);
            // List<Model.Customer> ListOfCustomers = new List<Model.Customer>();
            // foreach (var cust in result)
            // {
            //     ListOfCustomers.Add(new Model.Customer()
            //     {
            //         Id = cust.Id,
            //         Name = cust.Name,
            //         Address = cust.Address,
            //         EmailPhone = cust.EmailPhone

            //     });
            // }
            // return ListOfCustomers;
        }

        public Customer GetMatchingCustomer(string p_custName, string p_emailPhone)
        {
            var result = _context.Customers
                .FirstOrDefault<Customer>(cust => 
                    cust.Name == p_custName && cust.EmailPhone ==p_emailPhone);
            return new Customer()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Address = result.Address,
                    EmailPhone = result.EmailPhone
                };
        }

        public Customer GetMatchingCustomer(int p_custID)
        {
            var result = _context.Customers
                .FirstOrDefault<Customer>(cust =>
                    cust.Id == p_custID);
            return new Customer()
            {
                Id = result.Id,
                Name = result.Name,
                Address = result.Address,
                EmailPhone = result.EmailPhone
            };
        }
    }
}