using CleverCSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CleverCSM.Controllers.Api
{
    public class CompanyCustomerController : ApiController
    {
        private ApplicationDbContext _context;

        public CompanyCustomerController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/<controller>
        public IEnumerable<CompanyCustomer> Get()
        {
            return _context.CompanyCustomer.ToList();
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var companycustomer = _context.CompanyCustomer.SingleOrDefault(c => c.Id == id);

            if (companycustomer == null)
                return NotFound();

            return Ok(companycustomer);
        }
    }
}