using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CleverCSM.Models;


namespace CleverCSM.Controllers {
    public class ContactController : Controller
    {
        public ViewResult Index()
        {
            var contacts = GetContacts();

            return View(contacts);
        }

        public ActionResult Details(int id)
        {
            var contact = GetContacts().SingleOrDefault(c => c.Id == id);

            if (contact == null)
                return HttpNotFound();

            return View(contact);
        }

        private IEnumerable<Contact> GetContacts()
        {
            return new List<Contact>
            {
                new Contact { Id = 1, Name = "Paulin Delvaux" },
                new Contact { Id = 2, Name = "Champ 1" }
            };
        }
    }
}