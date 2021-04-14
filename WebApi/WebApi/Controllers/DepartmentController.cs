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
    public class DepartmentController : ControllerBase
    {
        private readonly Infrastructure.employeesContext _context;
        public DepartmentController(employeesContext context)
        {
            _context = context;
        }
        public IQueryable<Department> GetDepartmentsWithManagersNames()
        {
            return _context.Departments.Include(x => x.DeptManagers).ThenInclude(x => x.EmpNoNavigation);
        }
        [HttpGet]
        public ActionResult<IEnumerable<DTO.Department>> GetDepartmentsDetails()
        {
            var query = GetDepartmentsWithManagersNames();

            return query.AsEnumerable().Select(item => new DTO.Department
            {
                Id = item.DeptManagers.Select(x => x.EmpNo).FirstOrDefault(),
                DepartmentName = item.DeptName,
                Name = item.DeptManagers.Select(x => x.EmpNoNavigation.FirstName + " " + x.EmpNoNavigation.LastName).FirstOrDefault()
            }).ToList();
        }
        //[HttpPut]
        //public void UpdateDepartmentManager(int id, [FromBody] DTO.Department body)
        //{
        //    var entity = _context.Departments.Include(x => x.DeptManagers).FirstOrDefault().DeptManagers.Where(x => x.EmpNo == id).FirstOrDefault();
        //    if(entity != null)
        //    {

        //    }
        //}
    }
}
