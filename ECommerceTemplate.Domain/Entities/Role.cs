﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTemplate.Domain.Entities
{
    public class Role
    {
        public string Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}
