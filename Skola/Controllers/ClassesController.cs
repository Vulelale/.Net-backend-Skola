using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skola.BL;
using Skola.Data;
using Skola.Models.ViewModels;

namespace Skola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly ClassService _service;
        private readonly AppDbContext _context;
        public ClassesController(ClassService service, AppDbContext context)
        {
            _context = context;
            _service = service;
            
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ClassViewModel model)
        {
            _service.Add(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ClassViewModel model)
        {
            if (id != model.ClassId) return BadRequest();
            _service.Update(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }

        [HttpGet("codebooks/{name}")]
        public ActionResult<List<CodebookItemDto>> GetCodebookItems(string name)
        {
            var items = _context.CodebookItems
                .Where(ci => ci.Codebook.Name == name)
                .Select(ci => new CodebookItemDto
                {
                    ItemId = ci.ItemId,
                    Value = ci.Value
                })
                .ToList();

            return Ok(items);
        }

    }
}
