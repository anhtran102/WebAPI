using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// Class for task object
    /// </summary>
    public class AssigmentTask
    {
        public int Id { get; set; }
        public DateTime CompletedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartDate { get; set; }
        public string Subject { get; set; }
        public int Status { get; set; }
//        public int UserId { get; set; }
    }
}