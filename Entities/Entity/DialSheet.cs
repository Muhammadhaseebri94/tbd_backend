using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class DialSheet
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
    }
}
