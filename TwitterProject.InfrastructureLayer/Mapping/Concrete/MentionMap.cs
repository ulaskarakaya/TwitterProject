using Microsoft.EntityFrameworkCore;
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
    public class MentionMap:BaseMap<Mention>
    {
        public override void Configure(EntityTypeBuilder<Mention> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Text).HasColumnType("varchar(280)").IsRequired();
            base.Configure(builder);
        }
    }
}
