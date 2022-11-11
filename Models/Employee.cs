using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(150)]
        public string LastName { get; set; }
        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        public int Age { get; set; }
        public DateTime Doj { get; set; }
        public string Gender { get; set; }
        public int DesignationID { get; set; }

        [NotMapped]
        public string Designation { get; set; }
    }
}
