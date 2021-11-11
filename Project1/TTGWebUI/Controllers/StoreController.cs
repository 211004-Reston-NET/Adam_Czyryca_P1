using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTGBL;
using TTGWebUI.Models;
using TTGModel;


namespace TTGWebUI.Controllers
{
    public class StoreController : Controller
    {
        IStoreBL _storeBL;

        public StoreController(IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public ActionResult Index()
        {
            return View(_storeBL.GetAllStores()
                .Select(store => new StoreVM(store))
                .ToList()
            );
        }
    }
}
