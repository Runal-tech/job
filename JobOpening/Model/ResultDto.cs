using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace JobOpening.Model
{
    public class ResultDto
    {
        public bool Result { get; set; }

        public string ResultMessage { get; set; }

        public dynamic Details { get; set; }

        public HttpStatusCode Status { get; set; }
    }
}