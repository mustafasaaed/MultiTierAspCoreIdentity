using ECommerceTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTemplate.Domain.Repositories
{
    public interface IUserRoleRepository 
    {
        void Add(UserRole userRole);
        void Remove(UserRole userRole);
        IEnumerable<string> GetRoleNamesByUserId(string userId);
        IEnumerable<User> GetUsersByRoleName(string roleName);
    }
}
