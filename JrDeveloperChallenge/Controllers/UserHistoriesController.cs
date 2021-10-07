using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JrDeveloperChallenge.Models;

namespace JrDeveloperChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHistoriesController : ControllerBase
    {
        private readonly JrDeveloperChallengeContext _context;

        public UserHistoriesController(JrDeveloperChallengeContext context)
        {
            _context = context;
        }

        // GET: api/UserHistories
        [HttpGet]
        public IEnumerable<UserHistory> GetUserHistory()
        {
            return _context.UserHistory;
        }

        // GET: api/UserHistories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserHistory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userHistory = await _context.UserHistory.FindAsync(id);

            if (userHistory == null)
            {
                return NotFound();
            }

            return Ok(userHistory);
        }

        // PUT: api/UserHistories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserHistory([FromRoute] int id, [FromBody] UserHistory userHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(userHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserHistoryExists(id))
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

        // POST: api/UserHistories
        [HttpPost]
        public async Task<IActionResult> PostUserHistory([FromBody] UserHistory userHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserHistory.Add(userHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserHistory", new { id = userHistory.Id }, userHistory);
        }

        // DELETE: api/UserHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserHistory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userHistory = await _context.UserHistory.FindAsync(id);
            if (userHistory == null)
            {
                return NotFound();
            }

            _context.UserHistory.Remove(userHistory);
            await _context.SaveChangesAsync();

            return Ok(userHistory);
        }

        private bool UserHistoryExists(int id)
        {
            return _context.UserHistory.Any(e => e.Id == id);
        }
    }
}