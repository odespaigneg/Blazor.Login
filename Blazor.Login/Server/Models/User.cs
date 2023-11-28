using Microsoft.AspNetCore.Identity;
using System;

namespace Blazor.Login.Server.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
