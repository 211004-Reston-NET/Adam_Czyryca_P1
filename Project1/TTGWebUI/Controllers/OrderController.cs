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
    public class OrderController : Controller
    {
        IOrderBL _orderBL;
        IStoreBL _storeBL;

        public OrderController(IOrderBL p_orderBL, IStoreBL p_storeBL)
        {
            _orderBL = p_orderBL;
            _storeBL = p_storeBL;
        }

        public ActionResult Index()
        {
            //get list of customers from BL
            //converted model customer into customerVM using select method
            //toList to change it into a list
            return View(_orderBL.GetAllOrders()
                .Select(ord => new OrderVM(ord))
                .ToList()
            );
        }


        //-------------------------------------Create----------------------------------------
        // GET: CustomerController/Create
        [HttpGet]
        public IActionResult Create()
        {
            List<Store> ListOfStores = _storeBL.GetAllStores();
            List<StoreVM> StoreList = new List<StoreVM>();
            foreach (Store store in ListOfStores)
            {
                StoreList.Add(new StoreVM(store));
            }
            ViewBag.stores = StoreList;
            return View();
            //List<Store> ListOfStores = _storeBL.GetAllStores();
            //List<StoreVM> StoreList = new List<StoreVM>();
            //OrderVM TempOrd = new OrderVM();
            //foreach(Store store in ListOfStores)
            //{
            //    StoreList.Add(new StoreVM(store));
            //}
            //Tuple<IEnumerable<StoreVM>, OrderVM> StoreToSelect = new Tuple<IEnumerable<StoreVM>, OrderVM >(StoreList.AsEnumerable(), new OrderVM());

            //return View(StoreToSelect);
            ////return View(new OrderVM(){ StoreFront = p_storeId });
        }

        // POST: CustomerController/Create
        [HttpPost]
        public IActionResult Create(OrderVM order)
        {
            _orderBL.AddOrders(new Orders()
            {
                Customer = order.Customer,
                StoreFront = order.StoreFront,
                Total = 0
            });
            return RedirectToAction(nameof(Index));
        }


    }





}
