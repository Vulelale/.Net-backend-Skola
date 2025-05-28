using System;
using System.Collections.Generic;

namespace Skola.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public int GradeId { get; set; }

    public string Naziv { get; set; } = null!;

    public int VrstaOdeljenjaId { get; set; }

    public bool Kombinovano { get; set; }

    public bool CelodnevnaNastava { get; set; }

    public bool IzdvojenoOdeljenje { get; set; }

    public string? NazivIzdvojeneSkole { get; set; }

    public string? OdeljenjskiStaresina { get; set; }

    public string? Smena { get; set; }

    public int JezikNastaveId { get; set; }

    public bool DvojezicnoOdeljenje { get; set; }

    public int? PrviStraniJezikId { get; set; }

    public int UkupanBrojUcenika { get; set; }

    public int BrojUcenika { get; set; }

    public int BrojUcenica { get; set; }

    public virtual Grade Grade { get; set; } = null!;

    public virtual CodebookItem JezikNastave { get; set; } = null!;

    public virtual CodebookItem? PrviStraniJezik { get; set; }

    public virtual CodebookItem VrstaOdeljenja { get; set; } = null!;
}
