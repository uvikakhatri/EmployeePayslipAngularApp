using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeePayslipModel.Utility;

namespace EmployeePayslipModel.Models
{
    public class Employee
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
      
        [Required]
        [Range(0, int.MaxValue)]
        public int AnnualSalary { get; set; }

        [Required]
        [Range(0, 12)]
        public int SuperRate { get; set; }

       
        [Required]      
        public DateTime StartDate { get; set; }
    }
}
