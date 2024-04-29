using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class BaseEntity
    {
        public string? CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ModifiedById { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
