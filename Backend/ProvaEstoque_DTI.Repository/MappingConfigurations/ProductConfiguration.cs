using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaEstoque_DTI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaEstoque_DTI.Repository.MappingConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Identifier);

            builder.Property(x => x.Name);

            builder.Property(x => x.Price);
        }
    }
}
