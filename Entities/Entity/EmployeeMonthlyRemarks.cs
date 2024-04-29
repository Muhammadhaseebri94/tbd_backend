using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class EmployeeMonthlyRemarks:BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string RemarksOptionId { get; set; }
        public string Comments { get; set; }
    }
}
