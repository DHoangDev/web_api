using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiEF5.Models
{
    public partial class SalaryGrade
    {
        public int Grade { get; set; }
        public float HighSalary { get; set; }
        public float LowSalary { get; set; }
    }
}
