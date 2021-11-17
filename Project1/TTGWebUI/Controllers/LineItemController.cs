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
            List<ProductVM> ProdList = new List<ProductVM>();
            List<LineItemVM> ItemList = new List<LineItemVM>();
            for (int i = 0; i < ListOfLineItems.Count; i++)
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
            return View(new LineItemVM() { Store = p_storeId });
        }

        // POST: CustomerController/Create
        [HttpPost]
        //[Route("/LineItem/Create?{p_storeId=2}")]
        public ActionResult Create(int Id, LineItemVM LItemVM)
        {
            Product foundProd = _prodBL.GetProductByID(LItemVM.Product);
            Store foundStore = _storeBL.GetStoreById(LItemVM.Store);
            if (foundStore != null)
            {
                _lineItemBL.AddLineItem(new LineItem()
                {
                    Id = LItemVM.Id,
                    Quantity = LItemVM.Quantity,
                    Product = LItemVM.Product,
                    Store = LItemVM.Store
                });
            }

            return RedirectToAction("Index", "Store");
        }

        //-----------------------------------Delete------------------------------------------
        public ActionResult Delete(int p_Id)
        {
            LineItem LItem = _lineItemBL.GetMatchingLineItem(p_Id);
            Product prod = _prodBL.GetProductByID(LItem.Product);
          
            ProductVM prodVM = new ProductVM(prod);
            ViewData.Add("prodInLineItem", prodVM);
            return View(new LineItemVM(_lineItemBL.GetMatchingLineItem(p_Id)));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id, IFormCollection collection)
        {


            try
            {
                List<LineItem> ListOfItems = _lineItemBL.GetAllLineItems();
                foreach (LineItem item in ListOfItems)
                {
                    if (item.Id == Id)
                    {
                        _lineItemBL.DeleteItem(item);
                    }
                }
                return RedirectToAction("Index", "Store");

                //Customer CustToBeDeleted = _custBL.GetMatchingCustomer(Id);
                //_custBL.DeleteCustomer(CustToBeDeleted);
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                //return RedirectToAction(nameof(Index));
                return View();
            }
        
        }

        //-----------------------------------Modify------------------------------------------
        [HttpGet]
        public ActionResult Modify(int p_Id)
        {
            LineItem LItem = _lineItemBL.GetMatchingLineItem(p_Id);
            Product prod = _prodBL.GetProductByID(LItem.Product);
            SingletonProductVM.product = prod;
            //ProductVM prodVM = new ProductVM(prod);
            //ViewData.Add("prodInLineItem2", prodVM);
            return View(new LineItemVM(_lineItemBL.GetMatchingLineItem(p_Id)));
            //return View(new LineItemVM() { Store = p_storeId });
        }

        // POST: CustomerController/Create
        [HttpPost]
        //[Route("/LineItem/Create?{p_storeId=2}")]
        public ActionResult Modify(int Id, LineItemVM LItemVM)
        {
            try
            {
                List<LineItem> ListOfItems = _lineItemBL.GetAllLineItems();
     

                foreach (LineItem item in ListOfItems)
                {
                    if (item.Id == Id)
                    {
                        _lineItemBL.UpdateQuantity(Id,LItemVM.Quantity);
                        return RedirectToAction("Index", "Store");
                    }
                }
                return View();

                //Customer CustToBeDeleted = _custBL.GetMatchingCustomer(Id);
                //_custBL.DeleteCustomer(CustToBeDeleted);
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                //return RedirectToAction(nameof(Index));
                return View();
            }
 
        }
        //------------------------------------------------------------------------------------------------------
        // GET: LineItem/Edit/5
        public ActionResult Edit(int p_id)
        {
            LineItem itemFound = _lineItemBL.GetLineItemsById(p_id);
            return View(new LineItemVM(itemFound));
        }

        // POST: LineItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LineItemVM p_lineItemVM, int LineItemId)
        {
            try
            {
                LineItem itemToUpdate = _lineItemBL.GetLineItemsById(LineItemId);
                itemToUpdate.Quantity = p_lineItemVM.Quantity;
                _lineItemBL.RefreshStock(itemToUpdate);
                return RedirectToAction("Index", new
                {
                    p_storeId = itemToUpdate.Store
                });
            }
            catch (System.Exception exception)
            {
                Console.WriteLine(exception.Message);
                return View();
            }
        }



        //------------------------------------------------------------------------------


    }
}


