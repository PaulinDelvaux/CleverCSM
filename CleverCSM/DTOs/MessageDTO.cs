using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleverCSM.DTOs
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public ExchangeDTO Exchange { get; set; }
        public int ExchangeId { get; set; }
        public int CompanyCustomerId { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}