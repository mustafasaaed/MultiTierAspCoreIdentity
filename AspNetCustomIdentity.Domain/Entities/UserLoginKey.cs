using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCustomIdentity.Domain.Entities
{
    public class UserLoginKey
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}
