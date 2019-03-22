using AspNetCustomIdentity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCustomIdentity.Domain.Repositories
{
    public interface IRoleRepository : IRepository<Role, string>
    {
        Role FindByName(string roleName);
    }
}
