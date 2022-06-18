﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationCore.Entity
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public User? user { get; set; }
        public Role? Role { get; set; }
    }
}
