using TTGBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTGWebUI.Models;
using TTGModel;

namespace WebUI.Controllers
{
    public class LineItemController : Controller
    {
        private ILineItemBL _lineItemBL;
        private IProductBL _prodBL;
        private IStoreBL _storeBL;

        public LineItemController(ILineItemBL p_lineItemBL, IProductBL p_prodBL, IStoreBL p_storeBL)
        {
            _lineItemBL = p_lineItemBL;
            _prodBL = p_prodBL;
            _storeBL = p_storeBL;

        }
        //------------------------------------Index-----------------------------------------
        public ActionResult Index(int p_storeId)
        {
            //get list of customers from BL
            //converted model customer into customerVM using select method
            //toList to change it into a list
            return View(_lineItemBL.GetAllLineItems(p_storeId)
                .Select(item => new LineItemVM(item))
                .ToList()
            );
        }
        //-------------------------------------Inventory----------------------------------------
        // GET: LineItem
        public ActionResult Inventory(int p_storeId)
        {
            ViewData.Add("CurrentStoreFront", p_storeId);
            List<LineItem> ListOfLineItems = _lineItemBL.GetAllLineItems(p_storeId);
            List<ProductVM> ProdList=new List<ProductVM>();
            List<LineItemVM> ItemList = new List<LineItemVM>();
            for (int i=0; i< ListOfLineItems.Count; i++)
            {
                ProdList.Add(new ProductVM(_prodBL.GetProductByID(ListOfLineItems[i].Product)));
                ItemList.Add(new LineItemVM(ListOfLineItems[i]));
            }
            Tuple<IEnumerable<ProductVM>, IEnumerable<LineItemVM>> InventoryList = new Tuple<IEnumerable<ProductVM>, IEnumerable<LineItemVM>>(ProdList.AsEnumerable(), ItemList.AsEnumerable());

            return View(InventoryList);
        }
        //-----------------------------------create------------------------------------------
        // GET: CustomerController/Create
        [HttpGet]
        public ActionResult Create(int p_storeId)
        {
            return View(new LineItemVM(){Store = p_storeId});
        }

        // POST: CustomerController/Create
        [HttpPost]
        //[Route("/LineItem/Create?{p_storeId=2}")]
        public ActionResult Create(int Id, LineItemVM LItemVM)
        {
            Product foundProd = _prodBL.GetProductByID(LItemVM.Product);
            Store foundStore = _storeBL.GetStoreById(LItemVM.Store);
            if (foundStore!= null)
            {
                _lineItemBL.AddLineItem(new LineItem()
                {
                    Id = LItemVM.Id,
                    Quantity = LItemVM.Quantity,
                    Product = LItemVM.Product,
                    Store = LItemVM.Store
                });
            }

            return RedirectToAction(nameof(Inventory));
        }

        //-----------------------------------Delete------------------------------------------


        //-----------------------------------Modify------------------------------------------



        //------------------------------------------------------------------------------

    }
}


