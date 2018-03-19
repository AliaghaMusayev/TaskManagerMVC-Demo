using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    public class GeneralViewModel
    {
        public List<Users> selectedUsers { get; set; }
        public UserStatus userStatus { get; set; }
        public List<Tasks> userTasks { get; set; }

        
    }
}