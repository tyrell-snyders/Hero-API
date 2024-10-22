using Hero_API.Data;
using Hero_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;

namespace Hero_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        // ctx == context
        private readonly DataContext _ctx;

        public HeroController(DataContext ctx)
        {
            _ctx = ctx;
        }

        // Get all the heroes from the database
        [HttpGet]
        public async Task<ActionResult<List<Hero>>> GetHeroes()
        {
            var heroes = await _ctx.Heroes.ToListAsync();

            return Ok(heroes);
        }

        // Get a single hero from the database
        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(int id)
        {
            var hero = await _ctx.Heroes.FindAsync(id);
            if (hero is null)
                return NotFound("Hero Not Found");
            
            return Ok(hero);
        }

        // Add a hero
        [HttpPost]
        public async Task<ActionResult<string>> AddHero(Hero hero)
        {
            if (hero is null)
                return BadRequest("Wrong data");

            _ctx.Heroes.Add(hero);
            await _ctx.SaveChangesAsync();

            return Ok("New Hero Added");

        }

        [HttpPut]
        public async Task<ActionResult<Hero>> UpdateHero(Hero newHero)
        {
            var dbHero = await _ctx.Heroes.FindAsync(newHero.Id);
            if (dbHero is null)
                return NotFound("Hero Not Found");

            dbHero.Name = newHero.Name;
            dbHero.FullName = newHero.FullName;
            dbHero.LastName = newHero.LastName;
            dbHero.Place = newHero.Place;

            await _ctx.SaveChangesAsync();

            return Ok(await _ctx.Heroes.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<String>> DeleteHero(Hero hero)
        {
            if (hero == null)
                return NotFound("Hero Not Found");

            _ctx.Heroes.Remove(hero);
            await _ctx.SaveChangesAsync();

            return Ok($"{hero.Name} was deleted from the database.");
        }
    }
}
