using ECommerceTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTemplate.Domain.Repositories
{
    public interface IRoleRepository : IRepository<Role, string>
    {
        Role FindByName(string roleName);
    }
}
