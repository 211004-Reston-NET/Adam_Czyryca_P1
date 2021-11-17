using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTGModel;

namespace TTGWebUI.Models
{
    public class SingletonProductVM
    {
        public static Product product = new Product();
    }
}
