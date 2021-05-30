using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoveIT.Core.Models
{
    public class UserClaim : UserClaim<Guid>
    {

    }

    public class UserClaim<TKey> : IdentityUserClaim<TKey> where TKey : IEquatable<TKey>
    {

    }
}
