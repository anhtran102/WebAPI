﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName{get;set;}
        public string FirstName{get;set;}
        public string LastName { get; set; }       
    }
}