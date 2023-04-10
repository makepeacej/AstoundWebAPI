using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AstoundWebAPI.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Full Name")]
        public string? Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        [DisplayName("Tech Number")]
        public int TechNum { get; set; }
        [DisplayName("Job Category")]
        public Jobs? JobCategory { get; set; }
        //Manager, Install/Service, Network Tech, Sales, Office, Misc
    }

    public enum Jobs
    {
        Manager = 0,
        InstallOrService = 1,
        NetworkTech = 2,
        Sales = 3,
        Office = 4,
        Misc = 5
    }
}
