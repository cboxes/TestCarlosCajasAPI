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
    public class EnterprisesController : ControllerBase
    {
        private readonly EnterpriseDbContext _context;
        public EnterprisesController(EnterpriseDbContext enterpriseDbContext)
        {
            _context = enterpriseDbContext;
        }

        [HttpPost("add enterprise")]
        public async Task<IActionResult> AddEnterprises([FromBody] EnterpriseModel enterpriseObj)
        {
            //if(enterpriseObj == null)
            //{
            // return BadRequest();  
            //}
            //else
            //{
               

                await _context.enterpriseModels.AddAsync(enterpriseObj);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetEnterprise),enterpriseObj.Id,enterpriseObj);
                //return Ok(//new
                //{
                //    StatusCode = 200,
                //    Message = "Enterprise added Succesfully"
            //    }
            //);
            //}
        }

        [HttpPut("update enterprise")]
        public IActionResult UpdateEnterprise([FromBody] EnterpriseModel enterpriseObj)
        {
            if (enterpriseObj == null)
            {
                return BadRequest();
            }
            var user = _context.enterpriseModels.AsNoTracking().FirstOrDefault(x => x.Id == enterpriseObj.Id);
            if(user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Enterprise not found"
                });
            }
            else
            {
                _context.Entry(enterpriseObj).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(//new
                //{
                  //  StatusCode = 200,
                  //  Message = "Enterprise update Succefully"
            //    }
            ); 
            }
        }

        [HttpDelete("delete enterprise/id")]
        public IActionResult DeleteEnterprise(int id)
        {
            var user = _context.enterpriseModels.Find(id);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    message = "Enterprise not found"
                });
            }
            else
            {
                _context.Remove(user);
                _context.SaveChanges();
                return Ok(//new
                //{
                 //   StatusCode = 200,
                 //   Message = "Enterprise delete succefully"
            //    }
            );
            }
        }

        // get all enterprises
        [HttpGet("get_all_enterprise")]
        public async Task<IActionResult> GetAllEnterprises()
        {
            var enterprise = await _context.enterpriseModels.ToListAsync();
            //_context.enterpriseModels.AsQueryable();
            return Ok(//new
            //{
              //  StatusCode = 200,
                //EnterpriseDetails = 
                enterprise
            //}
            );
        }
        //get single enterprise
        [HttpGet("get enterprise/id")]
        public IActionResult GetEnterprise(int id)
        {
            var enterprise = _context.enterpriseModels.Find(id);
            if(enterprise == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Enterprise Not Found"
                });
            }
            else
            {
                return Ok(//new
                //{
                  //  StatusCode = 200,
                    //EnterpriseDetails =
                    enterprise
            //    }
            );
            }
        }
    }
}
    