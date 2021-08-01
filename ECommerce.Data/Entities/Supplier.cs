using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Entities
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<ProductSupplier> ProductSuppliers { get; set; }
    }
}