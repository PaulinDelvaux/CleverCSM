using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CleverCSM.Models;

namespace CleverCSM.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {
            var users = _context.User.Include(c=> c.AddressInfo).Include(b => b.Company).ToList();

            return View(users);
        }

        public ActionResult Details(int id)
        {
            var user = _context.User.Include(c => c.AddressInfo).Include(b => b.Company).SingleOrDefault(c => c.Id == id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

    }
}