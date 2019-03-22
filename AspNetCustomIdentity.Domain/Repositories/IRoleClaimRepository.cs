using AspNetCustomIdentity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCustomIdentity.Domain.Repositories
{
    public interface IRoleClaimRepository : IRepository<RoleClaim, int>
    {
        IEnumerable<RoleClaim> FindByRoleId(string roleId);
    }
}
