using AspNetCustomIdentity.Domain.Entities;
using AspNetCustomIdentity.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCustomIdentity.Data.Repositories
{
    internal class UserTokenRepository : BaseRepository, IRepository<UserToken, UserTokenKey>
    {

        public UserTokenRepository(DbContext context)
            : base(context)
        {

        }
        public void Add(UserToken entity)
        {
            Context.Set<UserToken>().Add(entity);
        }

        public IEnumerable<UserToken> All()
        {
            return Context.Set<UserToken>().ToList();
        }

        public UserToken Find(UserTokenKey key)
        {
             return Context.Set<UserToken>()
                .Where(u => u.UserId == key.UserId && u.LoginProvider == key.LoginProvider)
                .FirstOrDefault();
        }

        public void Remove(UserTokenKey key)
        {
            var userToken = Find(key);
            Context.Set<UserToken>().Remove(userToken);
        }

        public void Update(UserToken entity)
        {
            if (!Context.Set<UserToken>().Local.Any(ut => ut.LoginProvider == entity.LoginProvider && ut.UserId == entity.UserId))
            {
                Context.Set<UserToken>().Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                var userTokenKey = new UserTokenKey { UserId = entity.UserId, LoginProvider = entity.LoginProvider };
                var oldEntity = this.Find(userTokenKey);
                Context.Entry(oldEntity).CurrentValues.SetValues(entity);
            }
        }
    }
}
