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
    public class CustomerController : Controller
    {
        private ICustomerBL _custBL;
        private ILogInBL _logInBL;

        public CustomerController(ICustomerBL p_custBL, ILogInBL p_logInBL)
        {
            _custBL = p_custBL;
            _logInBL = p_logInBL;
        }
        //-------------------------------------index----------------------------------------

        // GET: CustomerController
        public ActionResult Index()
        {
            //get list of customers from BL
            //converted model customer into customerVM using select method
            //toList to change it into a list
            return View(_custBL.GetAllCustomers()
                .Select(cust => new CustomerVM(cust))
                .ToList()
            );
        }
        //---------------------------------------LogIn--------------------------------------
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(CustomerVM custVM)
        {
            Customer found = _custBL.GetMatchingCustomer(custVM.Name, custVM.EmailPhone);
            if (found != null)
            {
                SingletonCustomerVM.Customer = found;
                //ViewData.Add("CurrentCustomer", custVM);
                return RedirectToAction(nameof(Index));
            }
            //foreach (Customer cust in foundCust)
            //{
            //    if (cust.Name ==custVM.Name && cust.EmailPhone == custVM.EmailPhone)
            //    {
            //        ViewData.Add("CurrentCustomer", cust);
            //        return RedirectToAction(nameof(Index));
            //    }
            //}
            return View();

        }
        //-------------------------------------Create----------------------------------------
        // GET: CustomerController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        public IActionResult Create(CustomerVM custVM)
        {
            _custBL.AddCustomer(new Customer()
            {
                Name = custVM.Name,
                Address = custVM.Address,
                EmailPhone = custVM.EmailPhone
            });
            return RedirectToAction(nameof(Index));
        }

        //-----------------------------------Delete-----------------------------------------
        // GET: CustomerController/Delete/5
        public ActionResult Delete(int p_id)
        {
            //passing cust to preform delete on
            return View(new CustomerVM(_custBL.GetMatchingCustomer(p_id)));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id, IFormCollection collection)
        {
            

            try
            {
                List<Customer> ListOfCust = _custBL.GetAllCustomers();
                foreach (Customer cust in ListOfCust)
                {
                    if (cust.Id == Id)
                    {
                        _custBL.DeleteCustomer(cust);
                    }
                }
                return RedirectToAction(nameof(Index));

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
        //------------------------------------------------------------------------------
        //public ActionResult LogIn(string Name, String EmailPhone)
        //{
        //    return View(new CustomerVM(_custBL.GetMatchingCustomer(p_id)));
        //    //return View(_custBL.GetMatchingCustomer(Name, EmailPhone));

        //}



        //// GET: CustomerController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}



        //// GET: CustomerController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CustomerController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
