using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PermissionsToRole
    {
        public List<int> PermissionIds { get; set; }
        public string RoleId {  get; set; }
    }
}
