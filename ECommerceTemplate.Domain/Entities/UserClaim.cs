using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTemplate.Domain.Entities
{
    public class UserClaim : ClaimBase
    {
        public string UserId { get; set; }
    }
}
