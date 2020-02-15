using System;
using System.Collections.Generic;
using System.Text;

namespace tramiauto.Common.Model.Response
{
    public class ResponseAPI
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }
    }
}
