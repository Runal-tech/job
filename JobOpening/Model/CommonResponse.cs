using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobOpening.Model
{
    public class CommonResponse
    {
        public string Message { get; set; }

        public bool Success { get; set; }
    }

    public class CommonMessageResponse
    {
        public string Message { get; set; }
    }
}