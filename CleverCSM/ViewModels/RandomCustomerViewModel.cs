using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CleverCSM.Models;

namespace CleverCSM.ViewModels
{
    public class RandomCustomerViewModel
    {
        public Customer Customer { get; set; } 
        public List<Contact> Contact { get; set; }
    }
}