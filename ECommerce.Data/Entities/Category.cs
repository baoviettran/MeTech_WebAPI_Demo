﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SeoTitle { get; set; }
        public List<Product> Products { get; set; }
    }
}