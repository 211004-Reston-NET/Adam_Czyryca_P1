using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTGModel;

namespace TTGWebUI.Models
{
    public class SingletonCustomerVM
    {
        public static Customer Customer = new Customer();
        public static Customer Customer2 = new Customer();
    }
}
