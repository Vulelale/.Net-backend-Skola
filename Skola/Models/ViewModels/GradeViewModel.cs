namespace Skola.Models.ViewModels
{
    public class GradeViewModel
    {
        public int GradeId { get; set; }
        public string SkolskaGodina { get; set; }
        public string Razred { get; set; }
        public string Program { get; set; }
        public int UkupanBrojUcenika { get; set; }
        public int UkupanBrojOdeljenja { get; set; }
    }
}
