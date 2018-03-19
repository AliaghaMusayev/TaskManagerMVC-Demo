using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Tasks
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        public int UserId { get; set; }
        
        public DateTime Deadline { get; set; }

        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        public virtual List<Users> relatedUser { get; set; }

    }
}