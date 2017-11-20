using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CleverCSM.Models;
using CleverCSM.ViewModels;
using System.Data.Entity;


namespace CleverCSM.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var customer = _context.Customer.Include(c => c.AddressInfo).ToList();

            return View(customer);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            var companyId = customer.Id;

            _context.AddressInfo.Add(customer.AddressInfo);
            _context.SaveChanges();

            var aInfo = _context.AddressInfo.SingleOrDefault(c => c.Email == customer.AddressInfo.Email && c.Address == customer.AddressInfo.Address && c.Phone == customer.AddressInfo.Phone);

            customer.AddressInfoId = aInfo.Id;

            _context.Customer.Add(customer);
            _context.SaveChanges();
            
            var cInfo = _context.Customer.SingleOrDefault(c=>c.AddressInfoId==aInfo.Id);

            var combineInfo = new CompanyCustomer
            {
                CompanyId = companyId,
                CustomerId = cInfo.Id

            };

            _context.CompanyCustomer.Add(combineInfo);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }
    }
}