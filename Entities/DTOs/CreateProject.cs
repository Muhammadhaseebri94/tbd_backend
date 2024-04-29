using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CreateProject
    {
        public string ProjectTitle { get; set; }
        public DateTime BidDate { get; set; }
        public int NumOfDWGs { get; set; }
        public int ProjectTypeId { get; set; }

    }
}
