using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ViewModels.Common
{
    public class Response<T>
    {
        public bool IsSuccessed { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public Response()
        {
            IsSuccessed = true;
        }

        public Response(T data)
        {
            IsSuccessed = true;
            Data = data;
            Message = "Success";
        }

        public Response(string errorMessage)
        {
            IsSuccessed = false;
            Message = errorMessage;
        }
    }
}