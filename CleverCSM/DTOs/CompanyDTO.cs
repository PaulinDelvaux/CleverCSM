using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleverCSM.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressInfoDTO AddressInfo { get; set; }
        public int? AddressInfoId { get; set; }
    }
}