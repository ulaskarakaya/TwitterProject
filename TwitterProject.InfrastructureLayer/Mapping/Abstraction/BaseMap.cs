using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.DomainLayer.Entities.Abstraction;

namespace TwitterProject.InfrastructureLayer.Mapping.Abstraction
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Status).IsRequired(true);
            builder.Property(x => x.CreateDate).IsRequired(true);
            builder.Property(x => x.ModifiedDate).IsRequired(true);
            builder.Property(x => x.DeleteDate).IsRequired(true);
        }
    }
}
