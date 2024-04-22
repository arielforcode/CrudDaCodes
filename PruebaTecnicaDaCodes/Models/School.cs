using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaDaCodes.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Teacher { get; set; }
        [Required]
        public int NumberOfStudents { get; set; }
        [Required]
        public string Schedule { get; set; }
        public int ApprovedQuantities { get; set; }
        public int FailedAmounts { get; set; }
    }
}
