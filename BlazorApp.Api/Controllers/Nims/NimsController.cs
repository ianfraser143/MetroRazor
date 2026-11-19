using BlazorApp.Api.Commands;
using BlazorApp.Api.Queries;
using BlazorApp.Web.Data.Models;
using LiteBus;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NimsController : ControllerBase
    {
        private readonly ILiteBus _bus;

        public NimsController(ILiteBus bus)
        {
            _bus = bus;
        }

        // GET: api/nims
        [HttpGet]
        public async Task<ActionResult<List<ApplicationNims>>> GetAll()
        {
            var result = await _bus.QueryAsync(new GetAllNimsQuery());
            return Ok(result);
        }

        // GET: api/nims/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationNims>> GetById(string id)
        {
            var result = await _bus.QueryAsync(new GetNimsByIdQuery(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST: api/nims
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ApplicationNims nims)
        {
            await _bus.SendAsync(new CreateNimsCommand(nims));
            return CreatedAtAction(nameof(GetById), new { id = nims._id }, null);
        }

        // PUT: api/nims/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] ApplicationNims nims)
        {
            if (id != nims._id)
                return BadRequest("Id mismatch");
            await _bus.SendAsync(new UpdateNimsCommand(nims));
            return NoContent();
        }

        // DELETE: api/nims/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _bus.SendAsync(new DeleteNimsCommand(id));
            return NoContent();
        }
    }
}

