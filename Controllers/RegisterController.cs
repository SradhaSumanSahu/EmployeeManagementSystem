using EmployeeManagement.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class RegisterController : ControllerBase
    {
        private readonly IConfiguration _config;
        public readonly EmployeeContext _context;
        public RegisterController(IConfiguration config, EmployeeContext context)
        {
            _config = config;
            _context = context;
        }




        [HttpPost("CreateUser")]
        public IActionResult Create(Register register)//class Register
        {
            if (_context.registers.Where(u => u.Email == register.Email).FirstOrDefault() != null)
            {
                return Ok("This Email is Already Exists");
            }


            register.MemberSince = DateTime.Now;
            _context.registers.Add(register);
            _context.SaveChanges();
            return Ok("Success");

        }
    }
}
//https://localhost:44329/