﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomobileServiceStation.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string  Subject { get; set; }
        public string Message { get; set; }
    }
}