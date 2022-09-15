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
    public class DepartmentsController : ControllerBase
    {
        private readonly EnterpriseDbContext _context;
        public DepartmentsController(EnterpriseDbContext enterpriseDbContext)
        {
            _context = enterpriseDbContext;
        }

        [HttpPost("add department")]
        public IActionResult AddDepartmens([FromBody] DepartmentModel departmentObj)
        {
           // if (departmentObj == null)
           // {
           //     return BadRequest();
           // }
           // else
           // {
                _context.departmentModels.Add(departmentObj);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Getdepartment), departmentObj.Id, departmentObj);
            //  return Ok(//new
            //{
            //   StatusCode = 200,
            //  Message = "Department added Succesfully"
            //        }
            //);
            //   }
        }

        [HttpPut("update department")]
        public IActionResult UpdateDepartment([FromBody] DepartmentModel departmentObj)
        {
            if (departmentObj == null)
            {
                return BadRequest();
            }
            var user = _context.departmentModels.AsNoTracking().FirstOrDefault(x => x.Id == departmentObj.Id);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Department not found"
                });
            }
            else
            {
                _context.Entry(departmentObj).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(//new
              //  {
               //     StatusCode = 200,
               //     Message = "Department update Succefully"
                //}
                //
                );
            }
        }

        [HttpDelete("delete department/id")]
        public IActionResult DeleteDepartment(int id)
        {
            var user = _context.departmentModels.Find(id);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    message = "Department not found"
                });
            }
            else
            {
                _context.Remove(user);
                _context.SaveChanges();
                return Ok(//new
                //{
                 //   StatusCode = 200,
                 //   Message = "Department delete succefully"
            //    }
            );
            }
        }

        [HttpGet("get_all_department")]
        public IActionResult GetAllDepartments()
        {
            var department = _context.departmentModels.AsQueryable();
            return Ok(//new
            //{
            //    StatusCode = 200,
            //    DepartmentDetails =
                    department
        //    }
        );
        }

        [HttpGet("get department/id")]
        public IActionResult Getdepartment(int id)
        {
            var department = _context.departmentModels.Find(id);
            if (department == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Department Not Found"
                });
            }
            else
            {
                return Ok(//new
                //{
                //    StatusCode = 200,
                //    DepartmentDetails =
                        department
            //    }
            );
            }
        }
    }
}
