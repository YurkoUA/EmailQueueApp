using System;

namespace EmailQueueApp.Data.Entity
{
    public class MailingReportAddressEM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public DateTime SendingTime { get; set; }
        public int RepeatCount { get; set; }
        public int StatusId { get; set; }
    }
}
