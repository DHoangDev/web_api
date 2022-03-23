using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private async Task<IEnumerable<Employee>> getEmployeeById(Int16 id)
        {
            return await _context.Employees.Where(e => e.EmplId == id).ToListAsync();
        }

        private async Task<IEnumerable<Employee>> getAllEmployee()
        {
            return await _context.Employees.ToListAsync();
        }
        
        // GET: api/Employee
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            var res = await getAllEmployee();
            return res;
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Employee>> GetById(Int16 id)
        {
            var res = await getEmployeeById(id);
            return res;
        }
    }
}
