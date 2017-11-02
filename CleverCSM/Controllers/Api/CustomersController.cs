using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CleverCSM.Models;
using System.Data.Entity;

namespace CleverCSM.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customer.Include(c => c.AddressInfo).ToList();
        }

        // GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customer.Include(c=>c.AddressInfo).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        // POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            var companyId = customer.Id;

            _context.AddressInfo.Add(customer.AddressInfo);
            _context.SaveChanges();

            var aInfo = _context.AddressInfo.SingleOrDefault(c => c.Email == customer.AddressInfo.Email && c.Address == customer.AddressInfo.Address && c.Phone == customer.AddressInfo.Phone);

            customer.AddressInfoId = aInfo.Id;

            _context.Customer.Add(customer);
            _context.SaveChanges();

            var cInfo = _context.Customer.SingleOrDefault(c => c.AddressInfoId == aInfo.Id);

            var combineInfo = new CompanyCustomer
            {
                CompanyId = companyId,
                CustomerId = cInfo.Id
            };

            _context.CompanyCustomer.Add(combineInfo);
            _context.SaveChanges();

            return customer;
        }

        // PUT api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            _context.AddressInfo.Add(customer.AddressInfo);
            _context.SaveChanges();

            var aInfo = _context.AddressInfo.SingleOrDefault(c => c.Email == customer.AddressInfo.Email && c.Address == customer.AddressInfo.Address && c.Phone == customer.AddressInfo.Phone);

            customer.Id = id;
            customer.AddressInfoId = aInfo.Id;

            _context.Customer.Add(customer);
            _context.SaveChanges();
        }

        //DELETE api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customer.Remove(customer);
            _context.SaveChanges();
        }
    }
}
