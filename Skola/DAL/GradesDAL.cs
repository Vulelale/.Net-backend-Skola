using Skola.Data;
using Skola.Models;

public class GradesDAL
{
    public List<Grade> GetAllGrades()
    {
        using var context = new AppDbContext();
        return context.Grades.ToList();
    }

    public Grade GetById(int id)
    {
        using var context = new AppDbContext();
        return context.Grades.FirstOrDefault(g => g.GradeId == id);
    }

    public void Add(Grade grade)
    {
        using var context = new AppDbContext();
        context.Grades.Add(grade);
        context.SaveChanges();
    }

    public void Update(Grade grade)
    {
        using var context = new AppDbContext();
        context.Grades.Update(grade);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        using var context = new AppDbContext();
        var grade = context.Grades.Find(id);
        if (grade != null)
        {
            context.Grades.Remove(grade);
            context.SaveChanges();
        }
    }
}



