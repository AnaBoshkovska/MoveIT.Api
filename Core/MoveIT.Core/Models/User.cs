using System;

using Microsoft.AspNetCore.Identity;

namespace MoveIT.Core.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
