using System;
using System.Collections.Generic;

namespace JobPortal.Models;

public partial class TblDepartment
{
    public int DepartmentId { get; set; }

    public string Department { get; set; } = null!;

    public virtual ICollection<TblJob> TblJobs { get; } = new List<TblJob>();
}
