using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class RequestLeave
    {

        [Key]
        public int RequestLeaveId { get; set; }
        public string LeaveReason { get; set; }
        public string LeaveType { get; set; }
    }
}
