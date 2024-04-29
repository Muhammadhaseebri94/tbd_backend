using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }
        public string Icon { get; set; }
        public bool Parent { get; set; }
        public string? ParentName { get; set; }
    }
}
