using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF5.Models;

namespace WebApiEF5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly qlnvContext _context;

        public EmployeeController(qlnvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var res = _context.Employees.ToArray();
            var a = "hellow";
            return res;
        }
    }
}
