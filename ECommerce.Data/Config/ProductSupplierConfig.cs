using ECommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Config
{
    public class ProductSupplierConfig : IEntityTypeConfiguration<ProductSupplier>
    {
        public void Configure(EntityTypeBuilder<ProductSupplier> builder)
        {
            builder.ToTable("ProductSuppliers");
            builder.HasKey(ps => new { ps.ProductId, ps.SupplierId });
            builder.HasOne(ps => ps.Product)
               .WithMany(p => p.ProductSuppliers)
               .HasForeignKey(ps => ps.ProductId);

            builder.HasOne(p => p.Supplier)
                .WithMany(ps => ps.ProductSuppliers)
                .HasForeignKey(p => p.SupplierId);
        }
    }
}