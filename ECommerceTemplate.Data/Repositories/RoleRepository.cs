using ECommerceTemplate.Domain.Entities;
using ECommerceTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceTemplate.Data.Repositories
{
    internal class RoleRepository : BaseRepository, IRoleRepository
    {

        public RoleRepository(DbContext context)
            : base(context)
        {
        }

        public void Add(Role entity)
        {
            Context.Set<Role>().Add(entity);
        }

        public IEnumerable<Role> All()
        {
            return Context.Set<Role>().ToList();
        }

        public Role Find(string key)
        {
            return Context.Set<Role>().Find(key);
        }

        public Role FindByName(string roleName)
        {
            return Context.Set<Role>().Where(r => r.Name == roleName)
                .FirstOrDefault();
        }

        public void Remove(string key)
        {
            var roleToDelete = Context.Set<Role>()
                        .Where(rc => rc.Id == key)
                        .FirstOrDefault();

            if (roleToDelete != null)
            {
                Context.Set<Role>().Remove(roleToDelete);
            }
            else
            {
                throw new KeyNotFoundException("There is no Role  with the given id.");
            }
        }

        public void Update(Role entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.Set<Role>().Attach(entity);
        }
    }
}
