using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutomobileServiceStation.Models
{
    public class ServiceSubType
    {
        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("service")]

        public int serviceID { get; set; }
        public Service service { get; set; }
      
        public float? cost { get; set; }

        public bool check { get; set; }

    }
}