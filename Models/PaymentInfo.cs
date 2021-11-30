using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomobileServiceStation.Models
{
    public class PaymentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        public int TransactionId { get; set; }
    }
}