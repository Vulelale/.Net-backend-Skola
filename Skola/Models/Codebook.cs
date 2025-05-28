using System;
using System.Collections.Generic;

namespace Skola.Models;

public partial class Codebook
{
    public int CodebookId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CodebookItem> CodebookItems { get; set; } = new List<CodebookItem>();
}
