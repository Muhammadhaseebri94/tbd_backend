﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserToRole
    {
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
