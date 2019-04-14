namespace EmailQueueApp.Data.Entity
{
    public class ServiceMailEM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int RepeatCount { get; set; }
    }
}
