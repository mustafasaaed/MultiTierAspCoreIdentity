using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCustomIdentity.Domain.Entities
{
    public class RoleClaim : ClaimBase
    {
        public string RoleId { get; set; }
    }
}
