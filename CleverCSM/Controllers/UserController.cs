using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CleverCSM.Models;
using CleverCSM.ViewModels;
using System;
using System.Security.Cryptography;
using System.Text;

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
            var user = _context.User.Include(c => c.AddressInfo).Include(c => c.Company).SingleOrDefault(c => c.Id == id);
            var companycustomer = _context.CompanyCustomer.Where(c=>c.CompanyId ==user.CompanyId).ToList();
            var exchange = _context.Exhange.Include(c => c.Contact).Include(c => c.User).SingleOrDefault(c => c.UserId == id);
            var customer = _context.Customer.Include(c => c.AddressInfo).SingleOrDefault(c=>c.Id== user.CompanyId);
            var lotsofcustomer = _context.Customer.Include(c => c.AddressInfo).ToList();
            var lotsofcompany = _context.Company.Include(c => c.AddressInfo).ToList();
            var contact = _context.Contact.Include(c => c.Customer).Include(c => c.AddressInfo).Single();
            //var docs = _context.Document.Single();
            //var mails = _context.Email.Include(c => c.Contact).SingleOrDefault(c=>c.ContactId==contact.Id);
            
            var messages = _context.Message.Include(c => c.Exchange).ToList();

            var viewModel = new ViewCustomer
            {
                User = user,
                Customer = customer,
                LotsOfCustomer = lotsofcustomer,
                Company = lotsofcompany

            };
     
            if (user == null || id < 0)
                return RedirectToAction("Index", "User");

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(User user)
        {
            _context.AddressInfo.Add(user.AddressInfo);
            _context.SaveChanges();

            var aInfo = _context.AddressInfo.SingleOrDefault(c => c.Email == user.AddressInfo.Email && c.Address == user.AddressInfo.Address && c.Phone == user.AddressInfo.Phone);

            user.AddressInfoId = aInfo.Id;
            user.AddressInfoEmail = aInfo.Email;
            
            user.Password = GetMd5Hash(MD5.Create(), user.Password);

            _context.User.Add(user);
            _context.SaveChanges();

            var cInfo = _context.Customer.SingleOrDefault(c => c.AddressInfoId == aInfo.Id);

            return RedirectToAction("Index", "User");
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}