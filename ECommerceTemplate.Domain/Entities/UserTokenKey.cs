﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTemplate.Domain.Entities
{
    public class UserTokenKey
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
    }
}
