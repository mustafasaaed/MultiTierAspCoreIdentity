using ECommerceTemplate.Domain.Entities;
using ECommerceTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceTemplate.Data.Repositories
{
    internal class UserClaimRepository : BaseRepository, IUserClaimRepository
    {

        public UserClaimRepository(DbContext context)
            : base(context)
        {

        }
        public void Add(UserClaim entity)
        {
            Context.Set<UserClaim>().Add(entity);
        }

        public IEnumerable<UserClaim> All()
        {
            return Context.Set<UserClaim>().ToList();
        }

        public UserClaim Find(int key)
        {
            return Context.Set<UserClaim>().Find(key);
        }

        public IEnumerable<UserClaim> GetByUserId(string userId)
        {
            return Context.Set<UserClaim>().Where(rc => rc.UserId == userId).ToList();
        }

        public IEnumerable<User> GetUsersForClaim(string claimType, string claimValue)
        {
            var query = from u in Context.Set<User>()
                    join uc in Context.Set<UserClaim>()
                    on u.Id equals uc.UserId
                    where (uc.ClaimType == claimType && uc.ClaimValue == claimType)
                    select u;

            return query.ToList();
        }

        public void Remove(int key)
        {
             var userClaimToDelete = Context.Set<UserClaim>()
                        .Where(rc => rc.Id == key)
                        .FirstOrDefault();

            if (userClaimToDelete != null)
            {
                Context.Set<UserClaim>().Remove(userClaimToDelete);
            }
            else
            {
                throw new KeyNotFoundException("There is no User Claim with the given id.");
            }
        }

        public void Update(UserClaim entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.Set<UserClaim>().Attach(entity);
        }
    }
}
