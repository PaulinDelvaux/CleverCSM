using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CleverCSM.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public byte Type { get; set; }
        [Required]
        public AddressInfo AddressInfo { get; set; }
        public int? AddressInfoId { get; set; }
        [Required]
        public string AddressInfoEmail { get; set; }
        public Company Company { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}