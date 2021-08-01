using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ViewModels.Common
{
    public class PagingRequestFilter : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}