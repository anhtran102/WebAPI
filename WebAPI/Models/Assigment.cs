using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Assignment
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public float SpentHours { get; set; }
        public string Commnet { get; set; }
    }
}