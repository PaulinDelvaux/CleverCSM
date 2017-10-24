﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleverCSM.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public AddressInfo AddressInfo { get; set; }
        public int? AddressInfoId { get; set; }
    }
}   