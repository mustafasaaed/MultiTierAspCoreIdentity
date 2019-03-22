using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCustomIdentity.Domain.Entities
{
    public abstract class ClaimBase
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
