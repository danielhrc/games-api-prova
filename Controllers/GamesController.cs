using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesAPI.Models;
namespace GamesAPI.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
private readonly GamesContext _context;
public GamesController(GamesContext context)
{
_context = context;
if (_context.GamesItems.Count() == 0)
{
_context.GamesItems.Add(new GamesItem { Name = "Cod" });
_context.GamesItems.Add(new GamesItem { Name = "PES" });
_context.GamesItems.Add(new GamesItem { Name = "Fifa" });
_context.GamesItems.Add(new GamesItem { Name = "Winning eleveng" });
_context.SaveChanges();
}
}
 [HttpGet]
public async Task<ActionResult<IEnumerable<GamesItem>>> GetGamesItems() => await _context.GamesItems.ToListAsync();


        // GET: api/Games/5
[HttpGet("{id}")]
public async Task<ActionResult<GamesItem>> GetGamesItem(long id)
{
var gamesItem = await _context.GamesItems.FindAsync(id);
if (gamesItem == null)
{
return NotFound();
}
return gamesItem;
}

// DELETE: api/Games/5
[HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteGamesItem(long id)
        {
            var gamesItem = await _context.GamesItems.FindAsync(id);
            if (gamesItem == null)
            {
                return NotFound();
            }
            _context.GamesItems.Remove(gamesItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }



}


}