using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobOpening.Model
{
   
    public class Job
    {
        public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string location { get; set; }
        public string department { get; set; }
        public DateTime postedDate { get; set; }
        public DateTime closingDate { get; set; }
    }

    public class JobDetailsModel
    {
        public int total { get; set; }
        public List<Job> data { get; set; }
    }

}