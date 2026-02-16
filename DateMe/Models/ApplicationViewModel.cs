using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DateMe.Models
{
    public class ApplicationViewModel
    {
        [Key]
        [Required]
        public int ApplicationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey("MajorID")]
        public int MajorID { get; set; }
        public Major Major { get; set; }
        public string Occupation { get; set; }
        public bool CreeperStalker { get; set; }

    }
}
