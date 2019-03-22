using ECommerceTemplate.Domain.Entities;
using ECommerceTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceTemplate.Data.Repositories
{
    internal class UserRepository : BaseRepository, IUserRepository
    {

        public UserRepository(DbContext context)
            : base(context)
        {
        }

        public void Add(User entity)
        {
            Context.Set<User>().Add(entity);
        }

        public IEnumerable<User> All()
        {
            return Context.Set<User>().ToList();
        }

        public User Find(string key)
        {
            return Context.Set<User>().Find(key);
        }

        public User FindByNormalizedEmail(string normalizedEmail)
        {
            return Context.Set<User>().Where(u => u.NormalizedEmail == normalizedEmail)
               .FirstOrDefault();
        }

        public User FindByNormalizedUserName(string normalizedUserName)
        {
            return Context.Set<User>().Where(u => u.NormalizedUserName == normalizedUserName)
                         .FirstOrDefault();
        }

        public void Remove(string key)
        {
            var userToDelete = Context.Set<User>()
                                    .Where(u => u.Id == key)
                                    .FirstOrDefault();

            if (userToDelete != null)
            {
                Context.Set<User>().Remove(userToDelete);
            }
            else
            {
                throw new KeyNotFoundException("There is no user with the given id.");
            }
        }

        public void Update(User entity)
        {
            if (!Context.Set<User>().Local.Any(u => u.Id == entity.Id))
            {
                Context.Set<User>().Attach(entity);
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
