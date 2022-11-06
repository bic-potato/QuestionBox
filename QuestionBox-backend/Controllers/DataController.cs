using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace QuestionBox_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataDbContexts _context;
        public DataController(DataDbContexts context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModel>>> GetDataList()
        {

            if (_context.DataModel == null)
            {
                return NotFound();
            }
            return await _context.DataModel.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataModel>> GetData(string id)
        {
            if (_context.DataModel == null)
            {
                return NotFound();
            }
            var Gid = Guid.Parse(id);
            var content = await _context.FindAsync<DataModel>(Gid);
            if (content == null)
            {
                return NotFound();
            }
            return Ok(content);
        }

        [HttpPut("answer/{id}"), Authorize]
        public async Task<IActionResult> AnswerQuestion(string id, string answer)
        {
            var gid = Guid.Parse(id);
            var data = await _context.FindAsync<DataModel>(gid);
            if ( data == null )
            {
                return BadRequest();
            }

            data.Answers = answer;
            _context.Entry(data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataModelExists(gid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DataModel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("new-question")]
        public async Task<ActionResult<DataModel>> NewQuestion(string question)
        {
            if (_context.DataModel == null)
            {
                return Problem("Entity set 'DataContext.DataModel'  is null.");

            }

            DataModel data = new DataModel(Guid.NewGuid(), question, "");

            _context.DataModel.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DataModelExists(data.uid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDataModel", new { id = data.uid }, data);
        }

        // DELETE: api/DataModel/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteDataModel(long id)
        {
            if (_context.DataModel == null)
            {
                return NotFound();
            }
            var data = await _context.DataModel.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.DataModel.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataModelExists(Guid id)
        {
            return (_context.DataModel?.Any(e => e.uid == id)).GetValueOrDefault();
        }
    }

}

    