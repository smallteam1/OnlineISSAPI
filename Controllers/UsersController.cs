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
    public class UsersController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public UsersController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Users.ToListAsync());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if(user == null)
            {
                return NotFound("Record Not found");
            }
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            var userObj = await _dbContext.Users.FindAsync(id);

            if (userObj == null) 
            { 
                return NotFound("Record Not found"); 
            }
            else
            {
                userObj.UserSalaryId = user.UserSalaryId;
                userObj.UserName = user.UserName;
                userObj.UserPassword = user.UserPassword;
                userObj.UserRole = user.UserRole;
                userObj.UserEmail = user.UserEmail;
                return Ok("Record updated successfully");
            }

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userObj = await _dbContext.Users.FindAsync(id);

            if (userObj == null)
            { 
                return NotFound("Record Not found"); 
            }
            else
            {
                _dbContext.Users.Remove(userObj);
                await _dbContext.SaveChangesAsync();
                return Ok("Deleted successfully");
            }
        }
    }
}
