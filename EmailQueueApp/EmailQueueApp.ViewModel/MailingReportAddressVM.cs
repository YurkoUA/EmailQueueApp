using System;
using EmailQueueApp.ViewModel.Enums;

namespace EmailQueueApp.ViewModel
{
    public class MailingReportAddressVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public DateTime SendingTime { get; set; }
        public int RepeatCount { get; set; }
        public MailStatus Status { get; set; }
    }
}
