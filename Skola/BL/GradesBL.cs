using Skola.Data;
using Skola.Models;
using Skola.Models.DTOs;
using Skola.Models.ViewModels;

public class GradesBL
{
    private readonly AppDbContext _context;

    public GradesBL(AppDbContext context)
    {
        _context = context;
    }

    public List<GradeDto> GetAllWithNames()
    {
        return _context.Grades.Select(g => new GradeDto
        {
            GradeId = g.GradeId,
            SkolskaGodinaId = g.SkolskaGodinaId,
            RazredId = g.RazredId,
            ProgramId = g.ProgramId,
            SkolskaGodina = _context.CodebookItems.FirstOrDefault(ci => ci.ItemId == g.SkolskaGodinaId)!.Value,
            Razred = _context.CodebookItems.FirstOrDefault(ci => ci.ItemId == g.RazredId)!.Value,
            Program = _context.CodebookItems.FirstOrDefault(ci => ci.ItemId == g.ProgramId)!.Value,
            UkupanBrojUcenika = _context.Classes.Where(c => c.GradeId == g.GradeId).Sum(c => c.UkupanBrojUcenika),
            UkupanBrojOdeljenja = _context.Classes.Count(c => c.GradeId == g.GradeId)
        }).ToList();
    }

    public Grade GetById(int id) => _context.Grades.FirstOrDefault(g => g.GradeId == id);

    public void Add(Grade grade)
    {
        _context.Grades.Add(grade);
        _context.SaveChanges();
    }

    public void Update(Grade grade)
    {
        _context.Grades.Update(grade);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var grade = _context.Grades.Find(id);
        if (grade != null)
        {
            _context.Grades.Remove(grade);
            _context.SaveChanges();
        }
    }

    public List<CodebookItemDto> GetCodebookItems(string name)
    {
        return _context.CodebookItems
            .Where(ci => ci.Codebook.Name == name)
            .Select(ci => new CodebookItemDto { ItemId = ci.ItemId, Value = ci.Value })
            .ToList();
    }
}



