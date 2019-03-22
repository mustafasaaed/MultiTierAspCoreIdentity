using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCustomIdentity.Domain.Entities
{
    public class UserToken : UserTokenKey
    {
        public string Value { get; set; }
    }
}
