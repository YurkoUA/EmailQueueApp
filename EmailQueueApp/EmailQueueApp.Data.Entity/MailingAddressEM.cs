namespace EmailQueueApp.Data.Entity
{
    public class MailingAddressEM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int RepeatCount { get; set; }
    }
}
