using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Ordinal { get; set; }
    }
}