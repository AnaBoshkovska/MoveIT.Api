using System;

using Microsoft.AspNetCore.Identity;

namespace MoveIT.Core.Models
{
    public class RoleClaim : RoleClaim<Guid>
    {

    }

    public class RoleClaim<TKey> : IdentityRoleClaim<TKey> where TKey : IEquatable<TKey>
    {
        public RoleClaim() : base()
        {

        }
    }
}
