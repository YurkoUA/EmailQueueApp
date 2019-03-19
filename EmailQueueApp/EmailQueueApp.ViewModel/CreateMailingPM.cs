using System;
using System.Collections.Generic;

namespace EmailQueueApp.ViewModel
{
    public class CreateMailingPM
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendingTime { get; set; }
        public IEnumerable<MailingAddressVM> Adresses { get; set; }
    }
}
