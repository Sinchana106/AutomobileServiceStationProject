using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutomobileServiceStation.Models
{
    public class ServiceContext:DbContext
    {
        public DbSet<Service> services { get; set; }
        public DbSet<ServiceSubType> serviceSubType { get; internal set; }
    }
}