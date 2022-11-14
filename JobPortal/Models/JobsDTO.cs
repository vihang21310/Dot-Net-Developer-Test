namespace JobPortal.Models
{
    public class JobsDTO
    {

        public string? Title { get; set; }
        public string? Description { get; set; }

        public int LocationId { get; set; }
        public int Id { get; set; }

        public DateTime PostedDate { get; set; }

        public DateTime ClosingDate { get; set; }

        const int maxPageSize = 50;
        public int PageNo { get; set; }
        private int _pageSize;
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public int DepartmentId { get; set; }
        public string? Department { get; set; }
        public string? LocationTitle { get; set; }
        public int Total { get; internal set; }
        public List<JobsDTO>? JobList { get; set; }
        public string? Code { get; set; }


        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Zip { get; set; } = null!;


    }
}
