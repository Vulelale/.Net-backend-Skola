using System;
using System.Collections.Generic;

namespace Skola.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int SkolskaGodinaId { get; set; }

    public int RazredId { get; set; }

    public int ProgramId { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual CodebookItem Program { get; set; } = null!;

    public virtual CodebookItem Razred { get; set; } = null!;

    public virtual CodebookItem SkolskaGodina { get; set; } = null!;
}
