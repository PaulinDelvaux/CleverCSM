using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CleverCSM.Models;
using CleverCSM.ViewModels;

namespace CleverCSM.Controllers
{
    public class CompanyController : Controller
    {
        private ApplicationDbContext _context;

        public CompanyController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {
            var companies = _context.Company.ToList();

            return View(companies);
        }

        public ActionResult Details(int id)
        {
            var company = _context.Company.SingleOrDefault(c => c.Id == id);

            if (company == null)
                return HttpNotFound();

            return View(company);
        }

    }
}
