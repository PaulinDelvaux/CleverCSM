using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CleverCSM.Models;
using CleverCSM.ViewModels;

namespace CleverCSM.Controllers
{
    public class CustomerController : Controller
    {
        public ViewResult Index()
        {
            var customer = GetCustomers();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "DTU" },
                new Customer { Id = 2, Name = "KU" }
            };
        }

        // GET: Customer
        public ActionResult Random()
        {
            var customer = new Customer() { Name = "DTU" };
            var contact = new List<Contact>
            {
                new Contact {Name="Paulin Delvaux2" },
                new Contact {Name="Champ 2" }
            };

            var ViewModel = new RandomCustomerViewModel
            {
                Customer = customer,
                Contact= contact
            };

            return View(ViewModel);
        }
    }
}