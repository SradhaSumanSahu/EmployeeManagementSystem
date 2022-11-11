using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Login
    {
        [Key]
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
