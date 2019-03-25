namespace EmailQueueApp.ViewModel
{
    public class AddressPM
    {
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();
        public string Email { get; set; }
        public int RepeatCount { get; set; }
    }
}
