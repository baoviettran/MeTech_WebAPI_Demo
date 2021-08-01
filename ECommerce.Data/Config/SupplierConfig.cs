using ECommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Config
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Phone).IsRequired().HasMaxLength(10);
            builder.Property(s => s.Address).IsRequired().HasMaxLength(100);
        }
    }
}