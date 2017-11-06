using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleverCSM.DTOs
{
    public class CompanyCustomerDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
    }
}