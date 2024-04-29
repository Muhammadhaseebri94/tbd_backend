using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class Query:BaseEntity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int CompanyId { get; set; }
        public string QueryDetails { get; set; }
        public int QueryProgress { get; set; }
        public string QueryResponce { get; set; }
        public bool QueryResponded { get; set; }
    }
}
