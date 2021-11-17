﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutomobileServiceStation.Models
{
    public class Service
    {
        public int id { get; set; }
        [Display(Name ="NAME")]
        public string name { get; set; }
        public string photo { get; set; }

        public string desc { get; set; }
        public string cost { get; set; }

    }
}