using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pi.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pi.Data.Configurations
{
    internal class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();



            builder.ToTable("ShoppingCarts");
        }


    }
}
