using Microsoft.AspNetCore.Mvc;
using Skola.Data;
using Skola.Models;
using Skola.Models.DTOs;
using Skola.Models.ViewModels;

[Route("api/[controller]")]
[ApiController]
public class GradesController : ControllerBase
{
    private readonly GradesBL _bl;

    public GradesController(AppDbContext context)
    {
        _bl = new GradesBL(context);
    }

    [HttpGet("with-names")]
    public ActionResult<List<GradeDto>> GetWithNames()
    {
        try
        {
            return _bl.GetAllWithNames();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Greška: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Grade> GetById(int id)
    {
        var grade = _bl.GetById(id);
        return grade != null ? Ok(grade) : NotFound();
    }
    [HttpPost]
    public IActionResult Create([FromBody] GradeUpdateDto dto)
    {
        var grade = new Grade
        {
            SkolskaGodinaId = dto.SkolskaGodinaId,
            RazredId = dto.RazredId,
            ProgramId = dto.ProgramId
        };

        _bl.Add(grade);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] GradeUpdateDto dto)
    {
        if (id != dto.GradeId)
            return BadRequest("ID mismatch");

        var grade = _bl.GetById(id);
        if (grade == null) return NotFound();

        grade.SkolskaGodinaId = dto.SkolskaGodinaId;
        grade.RazredId = dto.RazredId;
        grade.ProgramId = dto.ProgramId;

        _bl.Update(grade);

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _bl.Delete(id);
        return Ok();
    }

    [HttpGet("codebooks/{name}")]
    public ActionResult<List<CodebookItemDto>> GetCodebook(string name) => _bl.GetCodebookItems(name);
}



