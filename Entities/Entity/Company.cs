using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class Company:BaseEntity
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? ContactPerson { get; set; }
        public string? OfficeContactNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailAddress { get; set; }
        public int SalesCount { get; set; }
        public DateTime LastPurchase { get; set; }
        public double TotalSales { get; set; }
        public int LastCallId { get; set; }
    }
}
