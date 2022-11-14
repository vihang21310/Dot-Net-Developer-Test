using System;
using System.Collections.Generic;

namespace JobPortal.Models;

public partial class TblJob
{
    public int JobId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Code { get; set; }

    public int DepartmentId { get; set; }

    public int LocationId { get; set; }

    public DateTime PostedDate { get; set; }

    public DateTime ClosingDate { get; set; }

    public virtual TblDepartment Department { get; set; } = null!;

    public virtual TblLocation Location { get; set; } = null!;
}
