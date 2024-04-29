using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class CallHistory
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int CompanyId { get; set; }
        public string HandledById { get; set; }
        public DateTime CallDateTime { get; set; }
        public int CallStatusId { get; set; }
        public string CompanyRemarks { get; set; }
        public int CallCount { get; set; }

    }
}