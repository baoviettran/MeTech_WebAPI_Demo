using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Entities
{
    public class ProductSupplier
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}