using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CleverCSM.Models;


namespace CleverCSM.Controllers {
    public class ContactController : Controller
    {
        private ApplicationDbContext _context;

        public ContactController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {
            var contacts = _context.Contact.ToList();

            return View(contacts);
        }

        public ActionResult Details(int id)
        {
            var contact = _context.Contact.SingleOrDefault(c => c.Id == id);

            if (contact == null)
                return HttpNotFound();

            return View(contact);
        }

    }
}