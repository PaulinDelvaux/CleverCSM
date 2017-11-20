using System.Data.Entity;
using System.Linq;
using CleverCSM.Models;
using CleverCSM.ViewModels;
using System.Web.Http;
using System.Collections.Generic;

namespace CleverCSM.Controllers.Api
{
    public class LoginsController : ApiController
    {
        private Models.ApplicationDbContext _context;

        public LoginsController()
        {
            _context = new ApplicationDbContext();

        }

        // GET /api/logins
        public IHttpActionResult GetLogins(int id)
        {

            var user = _context.User.Include(c => c.AddressInfo).Include(c => c.Company).SingleOrDefault(c => c.Id == id);
            var company = _context.Company.Single(c => c.Name == user.CompanyName);
            var companycustomer = _context.CompanyCustomer.Where(c=>c.CompanyId==company.Id).ToList();
            var exchange = _context.Exchange.Include(c => c.Contact).Include(c => c.User).Include(c => c.Contact.AddressInfo).Include(c => c.User.AddressInfo).Include(c => c.Contact.Customer).Include(c => c.User.Company).ToList();
           
            if (exchange == null)
                return NotFound();

            var viewLogin = new ViewLogin
            {
                Company = company,
                Exchange = exchange,
                CompanyCustomer = companycustomer

            };

            return Ok(viewLogin);
        }
    }
}
