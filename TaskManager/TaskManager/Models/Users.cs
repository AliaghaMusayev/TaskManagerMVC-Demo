using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Password { get; set; }

        public string Email { get; set; }

        public byte UserStatus { get; set; } = (int)Status.User;

        public virtual UserStatus relatedUserStatus { get; set; }
    }
}