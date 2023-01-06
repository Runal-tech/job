using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobOpening.Model
{
    
    public class JobDetails
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LocationID { get; set; }
        public int DepartmentID { get; set; }
        public DateTime ClosingDate { get; set; }

    }
    
    public class GetAllDetails
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllDetails()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public GetAllDetails(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }

    }
}