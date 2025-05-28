namespace Skola.Models.ViewModels
{
    public class ClassViewModel
    {
        public int ClassId { get; set; }
        public int GradeId { get; set; }
        public string Naziv { get; set; }
        public string Vrsta { get; set; }
        public string JezikNastave { get; set; }
        public bool Kombinovano { get; set; }
        public bool CelodnevnaNastava { get; set; }
        public bool IzdvojenoOdeljenje { get; set; }
        public string? NazivIzdvojeneSkole { get; set; }
        public string? OdeljenjskiStaresina { get; set; }
        public string? Smena { get; set; }
        public int UkupanBrojUcenika { get; set; }
        public int BrojUcenika { get; set; }
        public int BrojUcenica { get; set; }
    }
}
