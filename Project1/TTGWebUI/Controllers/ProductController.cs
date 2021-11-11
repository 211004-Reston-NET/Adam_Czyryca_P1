using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTGBL;
using TTGDL;

using TTGWebUI.Models;

namespace TTGWebUI.Models
{
    public class ProductController : Controller
    {

        IProductBL _prodBL;

        public ProductController(IProductBL p_prod)
        {
            _prodBL = p_prod;
        }
        public ActionResult Index()
        {
            //get list of products from BL
            //converted model product into productVM using select method
            //toList to change it into a list
            return View(_prodBL.GetAllProducts()
                .Select(prod => new ProductVM(prod))
                .ToList()
            );
        }
    }
}
