using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomobileServiceStation.Models
{
    public class ServiceCost
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }

        public float Cost { get; set; }
    }
}