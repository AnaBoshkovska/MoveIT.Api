using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoveIT.Core.Models
{
    public class UserToken : UserToken<Guid>
    {

    }

    public class UserToken<TKey> : IdentityUserToken<TKey> where TKey : IEquatable<TKey>
    {

    }
}
