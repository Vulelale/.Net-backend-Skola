namespace Skola.Models.DTOs
{
    public class GradeDto
    {
        public int GradeId { get; set; }
        public int SkolskaGodinaId { get; set; }
        public int RazredId { get; set; }
        public int ProgramId { get; set; }

        public string? SkolskaGodina { get; set; }
        public string? Razred { get; set; }
        public string? Program { get; set; }

        public int UkupanBrojUcenika { get; set; }
        public int UkupanBrojOdeljenja { get; set; }
    }
}
