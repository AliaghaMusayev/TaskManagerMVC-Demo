using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class UserStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public enum Status
    {
        Admin=1,
        User=2
    }
}