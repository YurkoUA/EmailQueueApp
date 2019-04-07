using System.ComponentModel.DataAnnotations;

namespace EmailQueueApp.ViewModel
{
    public class AddressPM
    {
        [ScaffoldColumn(false)]
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();

        [ScaffoldColumn(false)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public int RepeatCount { get; set; }
    }
}
