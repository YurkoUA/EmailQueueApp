using System.ComponentModel.DataAnnotations;

namespace EmailQueueApp.ViewModel.Enums
{
    public enum MailStatus
    {
        New = 1,

        [Display(Name = "In Queue")]
        InQueue = 2,

        Sent = 3,

        Error = 4
    }
}
