using ECommerceTemplate.Domain.Entities;
using ECommerceTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTemplate.Data.Repositories
{
    internal class RoleClaimRepository : BaseRepository, IRoleClaimRepository
    {
        public RoleClaimRepository(DbContext context)
            : base(context)
        {
        }

        public void Add(RoleClaim entity)
        {
            Context.Set<RoleClaim>().Add(entity);
        }

        public IEnumerable<RoleClaim> All()
        {
            return Context.Set<RoleClaim>().ToList();
        }

        public RoleClaim Find(int key)
        {
            return Context.Set<RoleClaim>().Find(key);
        }

        public IEnumerable<RoleClaim> FindByRoleId(string roleId)
        {
            return Context.Set<RoleClaim>().Where(rc => rc.RoleId == roleId).ToList();
        }

        public void Remove(int key)
        {
            var roleClaimToDelete = Context.Set<RoleClaim>()
                        .Where(rc => rc.Id == key)
                        .FirstOrDefault();

            if (roleClaimToDelete != null)
            {
                Context.Set<RoleClaim>().Remove(roleClaimToDelete);
            }
            else
            {
                throw new KeyNotFoundException("There is no Role Claim with the given id.");
            }
        }

        public void Update(RoleClaim entity)
        {
            if (!Context.Set<RoleClaim>().Local.Any(u => u.Id == entity.Id))
            {
                Context.Set<RoleClaim>().Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                var oldEntity = this.Find(entity.Id);
                Context.Entry(oldEntity).CurrentValues.SetValues(entity);
            }
        }
    }
}
