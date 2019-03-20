using ECommerceTemplate.Domain.Entities;
using ECommerceTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceTemplate.Data.Repositories
{
    internal class UserLoginRepository : BaseRepository, IUserLoginRepository
    {

        public UserLoginRepository(DbContext context)
            : base(context)
        {

        }
        public void Add(UserLogin entity)
        {
            Context.Set<UserLogin>().Add(entity);
        }

        public IEnumerable<UserLogin> All()
        {
            return Context.Set<UserLogin>().ToList();
        }

        public UserLogin Find(UserLoginKey key)
        {
            return Context.Set<UserLogin>()
                 .Where(ul => ul.LoginProvider == key.LoginProvider
                 && ul.ProviderKey == key.ProviderKey)
                 .FirstOrDefault();
        }

        public IEnumerable<UserLogin> FindByUserId(string userId)
        {
            return Context.Set<UserLogin>().Where(ul => ul.UserId == userId).ToList();
        }

        public void Remove(UserLoginKey key)
        {
            var entity =  Context.Set<UserLogin>().Where(ul => ul.LoginProvider == key.LoginProvider
                 && ul.ProviderKey == key.ProviderKey)
                 .FirstOrDefault();

            Context.Set<UserLogin>().Remove(entity);
        }

        public void Update(UserLogin entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.Set<UserLogin>().Attach(entity);
        }
    }
}
