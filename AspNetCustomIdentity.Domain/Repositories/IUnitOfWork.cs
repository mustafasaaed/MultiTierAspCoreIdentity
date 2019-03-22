using AspNetCustomIdentity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCustomIdentity.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository RoleRepository { get; }
        IRoleClaimRepository RoleClaimRepository { get; }
        IUserRepository UserRepository { get; }
        IUserClaimRepository UserClaimRepository { get; }
        IUserLoginRepository UserLoginRepository { get; }
        IRepository<UserToken, UserTokenKey> UserTokenRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }

        void Commit();
    }
}
