using System;
using System.Collections.Generic;

namespace stock_app_api.Models;

public partial class EducationResource
{
    public int ResourceId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? Category { get; set; }

    public DateTime? DatePublic { get; set; }
}
