using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.User.Api.Domain.Data.TypeConfigurations;
using Services.User.Api.Domain.Models;
using System;

namespace Services.User.Api.Domain.Data
{
    public class AppDbContext : IdentityDbContext<Models.User, IdentityRole<Guid>, Guid>
    {
        public IConfiguration Configuration;
        private readonly IWebHostEnvironment _env;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration, IWebHostEnvironment env) : base(options)
        {
            Configuration = configuration;
            _env = env;
        }

        //public AppDbContext() : base()
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UService.Logins");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UService.Token");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UService.UserClaim");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("UService.RoleClaim");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UService.UserRole");
            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("UService.Role");
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserRelationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InvitationEntityTypeConfiguration());
            //modelBuilder.Ignore<IdentityUserClaim<Guid>>();
            //modelBuilder.Ignore<IdentityRoleClaim<Guid>>();
            //modelBuilder.Ignore<IdentityUserRole<Guid>>();
            //modelBuilder.Ignore<IdentityRole<Guid>>();
        }

        public override DbSet<Models.User> Users { get; set; }
        public DbSet<UserRelation> UserFriends { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

    }
}
