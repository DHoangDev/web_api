using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiEF5.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Timekeepers = new HashSet<Timekeeper>();
        }

        public int EmplId { get; set; }
        public string EmplName { get; set; }
        public string EmplNo { get; set; }
        public DateTime HireDate { get; set; }
        public byte[] Image { get; set; }
        public string Job { get; set; }
        public float Salary { get; set; }
        public int DeptId { get; set; }
        public int MngId { get; set; }

        public virtual Department Dept { get; set; }
        public virtual Manager Mng { get; set; }
        public virtual ICollection<Timekeeper> Timekeepers { get; set; }
    }
}
