using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.InfrastructureLayer.Mapping.Concrete;

namespace TwitterProject.InfrastructureLayer.Context
{
    public class ApplicationDbContext: IdentityDbContext<AppUser, AppRole,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Mention> Mentions { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Share> Shares { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TweetMap());
            builder.ApplyConfiguration(new MentionMap());
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new LikeMap());
            builder.ApplyConfiguration(new FollowMap());
            builder.ApplyConfiguration(new ShareMap());
            
            base.OnModelCreating(builder);
        }
    }
}
