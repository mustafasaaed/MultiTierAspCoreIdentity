using ECommerceTemplate.Domain.Entities;
using ECommerceTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceTemplate.Data.Repositories
{
    internal class UserRoleRepository : BaseRepository, IUserRoleRepository
    {
        public UserRoleRepository(DbContext context)
            : base(context)
        {
        }

        public void Add(UserRole userRole)
        {
            Context.Set<UserRole>().Add(userRole);
        }

        public void Add(string userId, string roleName)
        {
            var role = Context.Set<Role>()
                .Where(r => r.Name == roleName)
                .FirstOrDefault();

            var userRole = new UserRole { RoleId = role.Id, UserId = userId };
            Add(userRole);
        }

        public IEnumerable<string> GetRoleNamesByUserId(string userId)
        {
            var query = from ur in Context.Set<UserRole>()
                    join r in Context.Set<Role>()
                    on ur.UserId equals userId
                    select r.Name;

            return query.ToList();
        }

        public IEnumerable<User> GetUsersByRoleName(string roleName)
        {
            var query = from r in Context.Set<Role>()
                        join u in Context.Set<User>()
                        on r.Name equals roleName
                        select u;

            return query.ToList();
        }


        public void Remove(string userId, string roleName)
        {
            var role = Context.Set<Role>()
               .Where(r => r.Name == roleName)
               .FirstOrDefault();

            var userRole = new UserRole { RoleId = role.Id, UserId = userId };
            Remove(userRole);
        }

        public void Remove(UserRole userRole)
        {
            Context.Set<UserRole>().Remove(userRole);
        }

    }
}
