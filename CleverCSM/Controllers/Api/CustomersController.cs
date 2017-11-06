using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using CleverCSM.Models;
using System.Data.Entity;
using CleverCSM.DTOs;
using AutoMapper;

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
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customer.Include(c => c.AddressInfo).ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customer.Include(c=>c.AddressInfo).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDTO>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerdto)
        {
            var customer = Mapper.Map<CustomerDTO, Customer>(customerdto);
            var addressinfo = Mapper.Map<AddressInfoDTO, AddressInfo>(customerdto.AddressInfo);

            var companyId = customerdto.Id;

            _context.AddressInfo.Add(addressinfo);
            _context.SaveChanges();

            var aInfo = _context.AddressInfo.SingleOrDefault(c => c.Email == customerdto.AddressInfo.Email && c.Address == customerdto.AddressInfo.Address && c.Phone == customerdto.AddressInfo.Phone);

            customerdto.AddressInfoId = aInfo.Id;

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

            customerdto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri+"/"+customerdto.Id),customerdto);
        }

        // PUT api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerdto)
        {
            var customer = Mapper.Map<CustomerDTO, Customer>(customerdto);
            var addressinfo = Mapper.Map<AddressInfoDTO, AddressInfo>(customerdto.AddressInfo);


            _context.AddressInfo.Add(addressinfo);
            _context.SaveChanges();

            var aInfo = _context.AddressInfo.SingleOrDefault(c => c.Email == customerdto.AddressInfo.Email && c.Address == customerdto.AddressInfo.Address && c.Phone == customerdto.AddressInfo.Phone);

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
