using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTGModel;

namespace TTGWebUI.Models
{
    public class CustomerVM
    {
        public CustomerVM()
        {

        }
        public CustomerVM(Customer p_cust)
        {
            this.Id = p_cust.Id;
            this.Name = p_cust.Name;
            this.Address = p_cust.Address;
            this.EmailPhone = p_cust.EmailPhone;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailPhone { get; set; }
    }
}
