using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class WorkingHour
    {
        [Key]
        public int CustoemerID { get; set; }
        public DateTime CompanyWorkingHours { get; set; }
        public DateTime EmployeeWorkingHours { get; set; }
    }
}
