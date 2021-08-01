using ECommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .IsUnicode().HasMaxLength(200);
            builder.Property(p => p.SeoTitle)
                .IsRequired()
                .HasMaxLength(120);
            builder.Property(p => p.Description)
                .IsRequired();
            builder.Property(p => p.OriginalPrice)
                .IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}