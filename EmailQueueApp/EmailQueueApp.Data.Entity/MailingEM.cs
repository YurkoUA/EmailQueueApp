using System;
using System.Collections.Generic;

namespace EmailQueueApp.Data.Entity
{
    public class MailingEM
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendingTime { get; set; }
        public IEnumerable<MailingAddressEM> Adresses { get; set; }
    }
}
