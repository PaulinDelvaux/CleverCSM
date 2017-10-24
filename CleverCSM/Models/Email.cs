using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleverCSM.Models
{
    public class Email
    {
        public int Id { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
        public string Text { get; set; }
        public string Header { get; set; }
        public DateTime Time
        { get; set; }

    }
}