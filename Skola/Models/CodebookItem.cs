using System;
using System.Collections.Generic;

namespace Skola.Models;

public partial class CodebookItem
{
    public int ItemId { get; set; }

    public int CodebookId { get; set; }

    public string Value { get; set; } = null!;

    public virtual ICollection<Class> ClassJezikNastaves { get; set; } = new List<Class>();

    public virtual ICollection<Class> ClassPrviStraniJeziks { get; set; } = new List<Class>();

    public virtual ICollection<Class> ClassVrstaOdeljenjas { get; set; } = new List<Class>();

    public virtual Codebook Codebook { get; set; } = null!;

    public virtual ICollection<Grade> GradePrograms { get; set; } = new List<Grade>();

    public virtual ICollection<Grade> GradeRazreds { get; set; } = new List<Grade>();

    public virtual ICollection<Grade> GradeSkolskaGodinas { get; set; } = new List<Grade>();
}
