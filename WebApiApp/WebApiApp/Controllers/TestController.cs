using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private DataContext? _db;
        public TestController(DataContext homeLibraryContext)
        {
            _db = homeLibraryContext;
        }
        [HttpGet]
        [Route("/Get")]
        public async Task<ActionResult<IEnumerable<Hero>>> Get()
        {
            return await _db.Heroes.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Hero>> Post(Hero hero)
        {
            if (hero == null)
                return BadRequest();
            _db.Heroes.Add(hero);
            await _db.SaveChangesAsync();
            return Ok(hero);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> Get(int id)
        {
            Hero hero = await _db.Heroes.FirstOrDefaultAsync(x => x.Id == id);
            if (hero == null)
                return NotFound();
            return new ObjectResult(hero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Hero>> Delete(int id)
        {
            Hero hero = _db.Heroes.FirstOrDefault(x => x.Id == id);
            if (hero == null)
            {
                return NotFound();
            }
            _db.Heroes.Remove(hero);
            await _db.SaveChangesAsync();
            return Ok(hero);
        }
    }
}