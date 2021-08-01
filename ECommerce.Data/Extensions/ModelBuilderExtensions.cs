using ECommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Quần bò nam", SeoTitle = "Quần bò nam" },
                new Category() { Id = 2, Name = "Áo sơ mi nam", SeoTitle = "Áo sơ mi nam" },
                new Category() { Id = 3, Name = "Giày cao gót", SeoTitle = "Giay cao gót" },
                new Category() { Id = 4, Name = "Giày thể thao nữ", SeoTitle = "Giày thể thao nữ" },
                new Category() { Id = 5, Name = "Phụ kiện", SeoTitle = "Phụ kiện" }
            );
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier() { Id = new Guid("191F2FA3-6090-4CD1-B455-E5BB9952FC56"), Name = "Adidas", Address = "New York", Phone = "0901534643" },
                new Supplier() { Id = new Guid("9AA6FDB5-A28E-49E5-B3CC-2AF2935C264C"), Name = "Nike", Address = "New York", Phone = "0901534643" },
                new Supplier() { Id = new Guid("B6D16C71-4095-429A-A5D8-6C426CE1D89E"), Name = "Canifa", Address = "New York", Phone = "0901534643" },
                new Supplier() { Id = new Guid("46DAEA1F-4CC9-4B8F-B5AC-8E868039FB42"), Name = "Uniquilo", Address = "Japan", Phone = "0901534643" }
           );
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = new Guid("007897E8-C8D5-4045-A374-F1E713B9D349"), CategoryId = 1, SeoTitle = "SeoTile", Name = "Quần Jean nam cao cấp Hàn Quốc", Description = "Description", OriginalPrice = 2000000, Price = 1500000 },
                new Product() { Id = new Guid("73C40B20-3957-4CC3-B469-7BF8710DA82E"), CategoryId = 2, SeoTitle = "SeoTile", Name = "Áo sơ mi cổ đức", Description = "Description", OriginalPrice = 2000000, Price = 1500000 },
                new Product() { Id = new Guid("F8CEE4D8-0786-416D-96FE-3F082BE58B2B"), CategoryId = 3, SeoTitle = "SeoTile", Name = "Guốc cao gót Quảng Châu", Description = "Description", OriginalPrice = 2000000, Price = 1500000 },
                new Product() { Id = new Guid("E8636A01-CA7C-4C7D-8F47-624FD31B5884"), CategoryId = 4, SeoTitle = "SeoTile", Name = "Giày thể thao Unisex", Description = "Description", OriginalPrice = 2000000, Price = 1500000 },
                new Product() { Id = new Guid("631FFA1E-9ADD-4F39-BB2B-8D2B23C872C9"), CategoryId = 4, SeoTitle = "SeoTile", Name = "Giày ", Description = "Description", OriginalPrice = 2000000, Price = 1500000 },
                new Product() { Id = new Guid("4AE4F1E4-F8A9-4686-9AE5-99636E3A9555"), CategoryId = 1, SeoTitle = "SeoTile", Name = "Quần baggy nam", Description = "Description", OriginalPrice = 2000000, Price = 1500000 },
                new Product() { Id = new Guid("0C64D061-EB9F-46CD-B764-784BD93F70D1"), CategoryId = 2, SeoTitle = "SeoTile", Name = "Áo sơ mi cúc bấm", Description = "Description", OriginalPrice = 2000000, Price = 1500000 },
                new Product() { Id = new Guid("4404EA65-0D55-41F7-9B59-7710E8DD5398"), CategoryId = 3, SeoTitle = "SeoTile", Name = "Guốc mũi nhọn", Description = "Description", OriginalPrice = 2000000, Price = 1500000 },
                new Product() { Id = new Guid("41B542AA-B862-43AB-9F0A-95AA18509BCD"), CategoryId = 1, SeoTitle = "SeoTile", Name = "Jean ống suông", Description = "Description", OriginalPrice = 2000000, Price = 1500000 },
                new Product() { Id = new Guid("ABCDE8BB-2D0C-467C-A7BA-885C9C13C52B"), CategoryId = 5, SeoTitle = "SeoTile", Name = "Đồng hồ nam cao cấp", Description = "Description", OriginalPrice = 2000000, Price = 1500000 },
                new Product() { Id = new Guid("3DF19266-984C-4239-AF67-32C79902BF88"), CategoryId = 2, SeoTitle = "SeoTile", Name = "Áo sơ mi họa tiết cáo", Description = "Description", OriginalPrice = 2000000, Price = 1500000 },
                new Product() { Id = new Guid("EFFF8436-5E87-4D1F-A433-6587BC15A630"), CategoryId = 1, SeoTitle = "SeoTile", Name = "Quần jean không gấu", Description = "Description", OriginalPrice = 2000000, Price = 1500000 }
                );
            modelBuilder.Entity<ProductSupplier>().HasData(
                new ProductSupplier() { ProductId = new Guid("007897E8-C8D5-4045-A374-F1E713B9D349"), SupplierId = new Guid("191F2FA3-6090-4CD1-B455-E5BB9952FC56") },
                new ProductSupplier() { ProductId = new Guid("73C40B20-3957-4CC3-B469-7BF8710DA82E"), SupplierId = new Guid("9AA6FDB5-A28E-49E5-B3CC-2AF2935C264C") },
                new ProductSupplier() { ProductId = new Guid("F8CEE4D8-0786-416D-96FE-3F082BE58B2B"), SupplierId = new Guid("B6D16C71-4095-429A-A5D8-6C426CE1D89E") },
                new ProductSupplier() { ProductId = new Guid("E8636A01-CA7C-4C7D-8F47-624FD31B5884"), SupplierId = new Guid("46DAEA1F-4CC9-4B8F-B5AC-8E868039FB42") },
                new ProductSupplier() { ProductId = new Guid("631FFA1E-9ADD-4F39-BB2B-8D2B23C872C9"), SupplierId = new Guid("191F2FA3-6090-4CD1-B455-E5BB9952FC56") },
                new ProductSupplier() { ProductId = new Guid("4AE4F1E4-F8A9-4686-9AE5-99636E3A9555"), SupplierId = new Guid("9AA6FDB5-A28E-49E5-B3CC-2AF2935C264C") },
                new ProductSupplier() { ProductId = new Guid("0C64D061-EB9F-46CD-B764-784BD93F70D1"), SupplierId = new Guid("191F2FA3-6090-4CD1-B455-E5BB9952FC56") },
                new ProductSupplier() { ProductId = new Guid("4404EA65-0D55-41F7-9B59-7710E8DD5398"), SupplierId = new Guid("191F2FA3-6090-4CD1-B455-E5BB9952FC56") },
                new ProductSupplier() { ProductId = new Guid("41B542AA-B862-43AB-9F0A-95AA18509BCD"), SupplierId = new Guid("9AA6FDB5-A28E-49E5-B3CC-2AF2935C264C") },
                new ProductSupplier() { ProductId = new Guid("ABCDE8BB-2D0C-467C-A7BA-885C9C13C52B"), SupplierId = new Guid("46DAEA1F-4CC9-4B8F-B5AC-8E868039FB42") },
                new ProductSupplier() { ProductId = new Guid("3DF19266-984C-4239-AF67-32C79902BF88"), SupplierId = new Guid("9AA6FDB5-A28E-49E5-B3CC-2AF2935C264C") },
                new ProductSupplier() { ProductId = new Guid("EFFF8436-5E87-4D1F-A433-6587BC15A630"), SupplierId = new Guid("46DAEA1F-4CC9-4B8F-B5AC-8E868039FB42") }
                );
        }
    }
}