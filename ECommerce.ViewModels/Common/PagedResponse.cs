using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ViewModels.Common
{
    public class PagedResponse<T>
    {
        public int TotalRecords { get; set; }

        public int TotalPages { get; set; }

        public List<T> Data { get; set; }
    }
}