using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiEF5.Models
{
    public partial class Manager
    {
        public Manager()
        {
            Employees = new HashSet<Employee>();
        }

        public int MngId { get; set; }
        public string MngPosition { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
