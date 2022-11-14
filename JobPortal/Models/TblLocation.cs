using System;
using System.Collections.Generic;

namespace JobPortal.Models;

public partial class TblLocation
{
    public int LocationId { get; set; }

    public string Title { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public virtual ICollection<TblJob> TblJobs { get; } = new List<TblJob>();
}
