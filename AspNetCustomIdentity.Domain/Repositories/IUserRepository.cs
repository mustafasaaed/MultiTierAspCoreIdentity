using AspNetCustomIdentity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCustomIdentity.Domain.Repositories
{
    public interface IUserRepository : IRepository<User, string>
    {
        User FindByNormalizedUserName(string normalizedUserName);

        User FindByNormalizedEmail(string normalizedEmail);
    }
}
