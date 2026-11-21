using BlazorApp.Api.Commands;
using BlazorApp.Api.Queries;
using BlazorApp.Web.Data.Models;
using LiteBus;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly ILiteBus _bus;

        public NoteController(ILiteBus bus)
        {
            _bus = bus;
        }

        // GET: api/notes
        [HttpGet]
        public async Task<ActionResult<List<Notes>>> GetAll()
        {
            var result = await _bus.QueryAsync(new GetAllNoteQuery());
            return Ok(result);
        }

        // GET: api/notes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Notes>> GetById(string id)
        {
            var result = await _bus.QueryAsync(new GetNoteByIdQuery(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST: api/notes
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Notes notes)
        {
            await _bus.SendAsync(new CreateNoteCommand(notes));
            return CreatedAtAction(nameof(GetById), new { id = notes.Id }, null);
        }

        // PUT: api/notes/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] Notes notes)
        {
            if (id != notes.Id)
                return BadRequest("Id mismatch");
            await _bus.SendAsync(new UpdateNoteCommand(notes));
            return NoContent();
        }

        // DELETE: api/notes/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _bus.SendAsync(new DeleteNoteCommand(id));
            return NoContent();
        }
    }
}


