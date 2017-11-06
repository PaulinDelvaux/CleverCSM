using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleverCSM.DTOs
{
    public class ExchangeDTO
    {
        public int Id { get; set; }
        public int CompanyCustomerId { get; set; }
        public UserDTO User { get; set; }
        public int UserId { get; set; }
        public ContactDTO Contact { get; set; }
        public int ContactId { get; set; }
        public DateTime NextContact { get; set; }
        public DateTime LastContact { get; set; }
        public int Frequency { get; set; }
        public int Priority { get; set; }
        public DateTime NextTryAttempt { get; set; }
        public DateTime LastTryAttempt { get; set; }
    }
}