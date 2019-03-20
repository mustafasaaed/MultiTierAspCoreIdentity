using ECommerceTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTemplate.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }



        //public DbSet<ClaimBase> ClaimBases { get; set; }
        //public DbSet<UserLoginKey> UserLoginKeys { get; set; }
        //public DbSet<UserTokenKey> UserTokenKeys { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserLoginKey>()
            //    .HasKey(ulk => new { ulk.LoginProvider, ulk.ProviderKey });

            //modelBuilder.Entity<UserRole>()
            //    .HasKey(ur => new { ur.RoleId, ur.UserId});

            modelBuilder.Entity<UserLogin>()
                .HasKey(ul => new { ul.UserId, ul.ProviderKey });

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.RoleId, ur.UserId });

            modelBuilder.Entity<UserToken>()
                .HasKey(ut => new { ut.UserId, ut.LoginProvider});

        }
    }
}




