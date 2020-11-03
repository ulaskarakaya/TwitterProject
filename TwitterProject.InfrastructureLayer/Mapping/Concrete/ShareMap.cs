using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.InfrastructureLayer.Mapping.Abstraction;

namespace TwitterProject.InfrastructureLayer.Mapping.Concrete
{
    public class ShareMap:BaseMap<Share>
    {
        public override void Configure(EntityTypeBuilder<Share> builder)
        {
            builder.HasKey(x => new { x.TweetId, x.AppUserId });
            base.Configure(builder);
        }
    }
}
