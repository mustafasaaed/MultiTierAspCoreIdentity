using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCustomIdentity.Domain.Entities
{
    public class UserClaim : ClaimBase
    {
        public string UserId { get; set; }
    }
}
