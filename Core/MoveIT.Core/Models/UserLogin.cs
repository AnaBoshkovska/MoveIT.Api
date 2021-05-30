using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoveIT.Core.Models
{
    public class UserLogin : UserLogin<Guid>
    {

    }

    public class UserLogin<TKey> : IdentityUserLogin<TKey> where TKey : IEquatable<TKey>
    {

    }
}
