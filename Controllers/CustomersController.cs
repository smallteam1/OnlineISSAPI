using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineISSAPI.Data;
using OnlineISSAPI.Properties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineISSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public CustomersController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Customers.ToListAsync());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound("Record Not found");
            }
            return Ok(customer);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Customer customer)
        {
            var customerObj = await _dbContext.Customers.FindAsync(id);

            if (customerObj == null)
            {
                return NotFound("Record Not found");
            }
            else
            {
                customerObj.GroupName = customer.GroupName;
                customerObj.GroupKey = customer.GroupKey;
                customerObj.LastContactedDate = customer.LastContactedDate;
                customerObj.LAAC = customer.LAAC;
                customerObj.LMU_Managed = customer.LMU_Managed;
                customerObj.Notes = customer.Notes;
                return Ok("Record updated successfully");
            }
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customerObj = await _dbContext.Customers.FindAsync(id);

            if (customerObj == null)
            {
                return NotFound("Record Not found");
            }
            else
            {
                _dbContext.Customers.Remove(customerObj);
                await _dbContext.SaveChangesAsync();
                return Ok("Deleted successfully");
            }
        }
    }
}
