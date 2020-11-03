using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;
using TwitterProject.DomainLayer.Entities.Concrete;
using TwitterProject.InfrastructureLayer.Mapping.Abstraction;

namespace TwitterProject.InfrastructureLayer.Mapping.Concrete
{
    public class FollowMap :BaseMap<Follow>
    {
        public override void Configure(EntityTypeBuilder<Follow> builder)
        {
            
            builder.HasKey(x => new { x.FollowerId, x.FollowingId });
            base.Configure(builder);
        }
    }
}
