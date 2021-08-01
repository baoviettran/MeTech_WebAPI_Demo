using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ViewModels.Product
{
    public class ProductUpdateRequest
    {
        public string Name { get; set; }
        public string SeoTitle { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
