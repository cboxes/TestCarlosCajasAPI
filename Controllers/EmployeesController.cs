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
    public class EmployeesController : ControllerBase
    {
        private readonly EnterpriseDbContext _context;
        public EmployeesController(EnterpriseDbContext enterpriseDbContext)
        {
            _context = enterpriseDbContext;
        }

        [HttpPost("add employee")]
        public IActionResult AddEmployees([FromBody] EmployeeModel employeeObj)
        {
            //if (employeeObj == null)
            //{
            //    return BadRequest();
            //}
            //else
            //{
                _context.employeeModels.Add(employeeObj);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetEmployee), employeeObj.Id, employeeObj);
            //return Ok(new
            //{
            //    StatusCode = 200,
            //    Message = "Employee added Succesfully"
            //});
            //}
        }

        [HttpPut("update employee")]
        public IActionResult UpdateEmployee([FromBody] EmployeeModel employeeObj)
        {
            if (employeeObj == null)
            {
                return BadRequest();
            }
            var user = _context.employeeModels.AsNoTracking().FirstOrDefault(x => x.Id == employeeObj.Id);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Employee not found"
                });
            }
            else
            {
                _context.Entry(employeeObj).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(//new
                //{
                //    StatusCode = 200,
                //    Message = "Employee update Succefully"
            //    }
            );
            }
        }

        [HttpDelete("delete employee/id")]
        public IActionResult DeleteEmployee(int id)
        {
            var user = _context.employeeModels.Find(id);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    message = "Employee not found"
                });
            }
            else
            {
                _context.Remove(user);
                _context.SaveChanges();
                return Ok(//new
                //{
                //    StatusCode = 200,
                //    Message = "Employee delete succefully"
            //    }
            );
            }
        }

        [HttpGet("get_all_employee")]
        public IActionResult GetAllEmployees()
        {
            var employee = _context.employeeModels.AsQueryable();
            return Ok(//new
            //{
            //    StatusCode = 200,
            //   EmployeeDetails =
                    employee
        //    }
        );
        }

        [HttpGet("get employee/id")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _context.employeeModels.Find(id);
            if (employee == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Employee Not Found"
                });
            }
            else
            {
                return Ok(//new
                //{
                //    StatusCode = 200,
                //    EmployeeDetails =
                        employee
            //    }
            );
            }
        }
    }
}
