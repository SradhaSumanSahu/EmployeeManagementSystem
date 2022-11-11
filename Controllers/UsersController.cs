using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly EmployeeContext _authcontext;

        public UsersController(EmployeeContext context)
        {
            _authcontext = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _authcontext.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _authcontext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }



        [HttpPost("authenticate")]
        public async Task<ActionResult<User>> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();
            var signup = await _authcontext.Users.FirstOrDefaultAsync(x => x.Username == userObj.Username && x.Password == userObj.Password);
            if (User == null)
                return NotFound(new { Message = "User Not Found" });

            return Ok(new
            {
                Message = "Login Success!"
            });
                _authcontext.Users.Add(userObj);
                await _authcontext.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { id = userObj.Id }, userObj);
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null) return BadRequest();


            await _authcontext.Users.AddAsync(userObj);
            await _authcontext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Register"
            });

        }
    }
}
