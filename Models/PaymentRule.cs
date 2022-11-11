using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class PaymentRule
    {
        [Key]
        public int PaymentID { get; set; }
        public string PaymentStatus { get; set; }
    }
}
