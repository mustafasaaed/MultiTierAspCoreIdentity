using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTemplate.Domain.Entities
{
    public class UserToken : UserTokenKey
    {
        public string Value { get; set; }
    }
}
