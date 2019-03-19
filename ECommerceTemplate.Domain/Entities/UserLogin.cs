using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTemplate.Domain.Entities
{
    public class UserLogin : UserLoginKey
    {
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }
    }
}
