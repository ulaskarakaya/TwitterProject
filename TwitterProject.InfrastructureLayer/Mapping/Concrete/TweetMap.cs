using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.InfrastructureLayer.Mapping.Abstraction;

namespace TwitterProject.InfrastructureLayer.Mapping.Concrete
{
    public class TweetMap:BaseMap<Tweet>
    {
        public override void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.ImagePath).IsRequired(false);
            builder.HasMany(x => x.Mentions).WithOne(x => x.Tweet).HasForeignKey(x => x.TweetId);
            builder.HasMany(x => x.Likes).WithOne(x => x.Tweet).HasForeignKey(x => x.TweetId);
            builder.HasMany(x => x.Shares).WithOne(x => x.Tweet).HasForeignKey(x => x.TweetId);
            base.Configure(builder);
        }
    }
}
