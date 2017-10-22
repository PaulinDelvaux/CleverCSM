using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleverCSM.Models
{
    public class Document
    {
        public int Id { get; set; }
        public int CompanyCustomerId { get; set; }
        public string Path { get; set; }
    }
}