using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CleverCSM.Models;

namespace CleverCSM.ViewModels
{
    public class ViewCustomer
    {
        public AddressInfo AddressInfo { get; set; }
        public IEnumerable<Company> Company { get; set; }
        public CompanyCustomer CompanyCustomer { get; set; }
        public Contact Contact { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Customer> LotsOfCustomer { get; set; }
        public Document Document { get; set; }
        public Email Email { get; set; }
        public Exchange Exchange { get; set; }
        public Message Message { get; set; }
        public User User { get; set; }
        public IEnumerable<Types> Type = new List<Types> {new Types {Id = 0,Name = "SuperAdmin"}, new Types {Id = 1,Name = "Admin"},new Types {Id = 2,Name = "User" },new Types {Id = 3,Name = "Contact" }};


    }
    public class Types
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ViewLogin
    {
        public Company Company { get; set; }
        public IEnumerable<CompanyCustomer> CompanyCustomer { get; set; }
        public IEnumerable<Exchange> Exchange { get; set; }
    }
}