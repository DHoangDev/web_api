using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiEF5.Models
{
    public partial class Timekeeper
    {
        public string TimekeeperId { get; set; }
        public DateTime DateTime { get; set; }
        public string InOut { get; set; }
        public int EmplId { get; set; }

        public virtual Employee Empl { get; set; }
    }
}
