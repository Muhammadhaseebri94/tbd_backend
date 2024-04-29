using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class Addendum:BaseEntity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int CompanyId { get; set; }
        public string AddendumDetails { get; set; }
        public int AddendumNumber { get; set; }
        public int AddendumProgressPercentage { get; set; }
        public string ConcernedEstimator { get; set; }
        public string AddendumResponce { get; set; }
        public bool AddentdumResponded { get; set; }

    }
}
