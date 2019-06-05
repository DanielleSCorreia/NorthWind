using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using (CustomerModel model = new CustomerModel())
            {
                IList<Customer> lista = model.Read();
                return View(lista);
            }                
        }

    }
}