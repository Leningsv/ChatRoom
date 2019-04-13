using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChatRoom.Models.Users
{
    public struct UserModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        [Required]
        public string Key { get; set; } // Identity server user sub
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
