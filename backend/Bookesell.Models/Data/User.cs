﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Bookesell.Models.Data
{
    public partial class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Roleid { get; set; }

        public virtual Role Role { get; set; }
    }
}