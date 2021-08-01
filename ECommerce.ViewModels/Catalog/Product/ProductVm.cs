using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ViewModels.Product
{
    public class ProductVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SeoTitle { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
