using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleverCSM.Models
{
    public class CompanyCustomer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }

    }
}