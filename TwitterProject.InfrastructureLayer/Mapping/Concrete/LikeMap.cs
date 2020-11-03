using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.InfrastructureLayer.Mapping.Abstraction;

namespace TwitterProject.InfrastructureLayer.Mapping.Concrete
{
    public class LikeMap:BaseMap<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(x => new { x.AppUserId, x.TweetId });
            base.Configure(builder);
        }
    }
}
