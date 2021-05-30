using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoveIT.Core.Models
{
    public class UserRole : UserRole<Guid>
    {

    }

    public class UserRole<TKey> : IdentityUserRole<TKey> where TKey : IEquatable<TKey>
    {
        
    }
}
