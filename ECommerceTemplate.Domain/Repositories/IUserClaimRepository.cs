using ECommerceTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTemplate.Domain.Repositories
{
    public interface IUserClaimRepository : IRepository<UserClaim, int>
    {
        IEnumerable<UserClaim> GetByUserId(string userId);
        IEnumerable<User> GetUsersForClaim(string claimType, string claimValue);
    }
}
