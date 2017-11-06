using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CleverCSM.Models;
using CleverCSM.ViewModels;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace CleverCSM.Controllers
{
    public class UserController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var user = _context.User.Include(c => c.AddressInfo).Include(c => c.Company).SingleOrDefault(c => c.Id == id);
            var exchange = _context.Exchange.Include(c => c.Contact).Include(c => c.User).SingleOrDefault(c => c.User.Id == id);
            var lotsofcustomer = _context.Customer.Include(c => c.AddressInfo).ToList();
            var lotsofcompany = _context.Company.Include(c => c.AddressInfo).ToList();
            var contact = _context.Contact.Include(c => c.Customer).Include(c => c.AddressInfo).Single();
            //var docs = _context.Document.Single();
            //var mails = _context.Email.Include(c => c.Contact).SingleOrDefault(c=>c.ContactId==contact.Id);
            
            var messages = _context.Message.Include(c => c.Exchange).ToList();

            var viewModel = new ViewCustomer
            {
                User = user,
                LotsOfCustomer = lotsofcustomer,
                Company = lotsofcompany

            };
     
            if (user == null || id == null)
                return RedirectToAction("Index", "User");

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Save(User user)
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
            
            var newuser = new ApplicationUser { UserName = user.Name, Email = user.AddressInfoEmail };
            await UserManager.CreateAsync(newuser, user.Password);
            await SignInManager.SignInAsync(newuser, isPersistent: false, rememberBrowser: false);

            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            // Send an email with this link
            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
            // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            return RedirectToAction("Index", "Home");
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