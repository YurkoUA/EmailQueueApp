using System;
using System.Collections.Generic;

namespace EmailQueueApp.ViewModel
{
    public class CreateMailingPM
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendingTime { get; set; }
        public List<AddressPM> Adresses { get; set; } = new List<AddressPM>();
    }
}
