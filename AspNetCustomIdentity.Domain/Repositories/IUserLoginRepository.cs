using AspNetCustomIdentity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCustomIdentity.Domain.Repositories
{
    public interface IUserLoginRepository : IRepository<UserLogin, UserLoginKey>
    {
        IEnumerable<UserLogin> FindByUserId(string userId);
    }
}
