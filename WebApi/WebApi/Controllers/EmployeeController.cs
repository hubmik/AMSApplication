using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Infrastructure;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Infrastructure.employeesContext _context;
        public EmployeeController(employeesContext context)
        {
            _context = context;
        }

        public IQueryable<Employee> GetEmployeesDetails()
        {
            return _context.Employees.Include(x => x.Salaries).Include(x => x.Titles);
        }

        [HttpGet]
        public ActionResult<IEnumerable<DTO.Employee>> GetEmployeesData()
        {
            var query = GetEmployeesDetails();
            return query.AsEnumerable().Select(item => new DTO.Employee
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                BirthDate = item.BirthDate,
                Gender = item.Gender,
                HireDate = item.HireDate,
                Title = item.Titles.FirstOrDefault().Title1,
                Salary = item.Salaries.FirstOrDefault().Salary1
            }).ToList();
        }
    }
}
