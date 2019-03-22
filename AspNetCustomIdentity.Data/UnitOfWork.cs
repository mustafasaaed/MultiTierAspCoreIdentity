using AspNetCustomIdentity.Data.Repositories;
using AspNetCustomIdentity.Domain.Entities;
using AspNetCustomIdentity.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCustomIdentity.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        #region Fields
        private DbContext _context;
        private IRoleRepository _roleRepository;
        private IRoleClaimRepository _roleClaimRepository;
        private IUserRepository _userRepository;
        private IUserClaimRepository _userClaimRepository;
        private IUserLoginRepository _userLoginRepository;
        private IRepository<UserToken, UserTokenKey> _userTokenRepository;
        private IUserRoleRepository _userRoleRepository;
        private bool _disposed;
        #endregion

        #region Members
        public IRoleRepository RoleRepository
        {
            get
            {
                return _roleRepository ?? (_roleRepository = new RoleRepository(_context));
            }
        }

        public IRoleClaimRepository RoleClaimRepository
        {
            get
            {
                return _roleClaimRepository ?? (_roleClaimRepository = new RoleClaimRepository(_context));
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? (_userRepository = new UserRepository(_context));
            }
        }

        public IUserClaimRepository UserClaimRepository
        {
            get
            {
                return _userClaimRepository ?? (_userClaimRepository = new UserClaimRepository(_context));
            }
        }

        public IUserLoginRepository UserLoginRepository
        {
            get
            {
                return _userLoginRepository ?? (_userLoginRepository = new UserLoginRepository(_context));
            }
        }

        public IRepository<UserToken, UserTokenKey> UserTokenRepository
        {
            get
            {
                return _userTokenRepository ?? (_userTokenRepository = new UserTokenRepository(_context));
            }
        }

        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                return _userRoleRepository ?? (_userRoleRepository = new UserRoleRepository(_context));
            }
        }

        #endregion
        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                // TO DO
                ResetRepositories();
            }
        }

        private void ResetRepositories()
        {
            _roleRepository = null;
            _roleClaimRepository = null;
            _userRepository = null;
            _userClaimRepository = null;
            _userLoginRepository = null;
            _userTokenRepository = null;
            _userRoleRepository = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
    }
}
