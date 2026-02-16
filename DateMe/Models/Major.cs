using System.ComponentModel.DataAnnotations;

namespace DateMe.Models
{
    public class Major
    {
        [Key]
        public int MajorID { get; set; }

        public string? MajorName { get; set; }
    }
}
