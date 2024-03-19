using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Models
{
    public class UserModel
    {
            public string Username { get; set; } = null!;

            public Roles Role { get; set; }
    }

    public class UserCreateModel
    {
            public string Username { get; set; } = null!;

            public string Password { get; set; } = null!;

            public Roles Role { get; set; }
    }
}