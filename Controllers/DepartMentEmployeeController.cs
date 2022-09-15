using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCarlosCajasAPI.Data;
using TestCarlosCajasAPI.Models;

namespace TestCarlosCajasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartMentEmployeeController : ControllerBase
    {
        private readonly EnterpriseDbContext _context;
        public DepartMentEmployeeController(EnterpriseDbContext enterpriseDbContext)
        {
            _context = enterpriseDbContext;
        }

        [HttpPost("add department_employee")]
        public IActionResult AddDepartEmployees([FromBody] Department_EmployeeModel departemployeeObj)
        {
            if (departemployeeObj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.department_EmloyeeModels.Add(departemployeeObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Department Employee added Succesfully"
                });
            }
        }

        [HttpPut("update department_employee")]
        public IActionResult UpdateDepartEmployee([FromBody] Department_EmployeeModel departemployeeObj)
        {
            if (departemployeeObj == null)
            {
                return BadRequest();
            }
            var user = _context.department_EmloyeeModels.AsNoTracking().FirstOrDefault(x => x.Id == departemployeeObj.Id);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Department Employee not found"
                });
            }
            else
            {
                _context.Entry(departemployeeObj).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Department Employee update Succefully"
                });
            }
        }

        [HttpDelete("delete department_employee/{id}")]
        public IActionResult DeleteDepartmentEmployee(int id)
        {
            var user = _context.department_EmloyeeModels.Find(id);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    message = "Department Employee not found"
                });
            }
            else
            {
                _context.Remove(user);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Department Employee delete succefully"
                });
            }
        }

        [HttpGet("get_all_department_employee")]
        public IActionResult GetAllDepartmentEmployees()
        {
            var deemployee = _context.department_EmloyeeModels.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                DepartEmployeeDetails = deemployee
            });
        }

        [HttpGet("get department_employee/id")]
        public IActionResult GetDepartmentEmployee(int id)
        {
            var deemployee = _context.department_EmloyeeModels.Find(id);
            if (deemployee == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Department Employee Not Found"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    EmployeeDetails = deemployee
                });
            }
        }
    }
}
