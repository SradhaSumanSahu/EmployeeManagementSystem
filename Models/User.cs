﻿namespace EmployeeManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string firstame { get; set; }
        public string  Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
