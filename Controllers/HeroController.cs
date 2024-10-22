using Hero_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hero_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetHeroes()
        {
            var heroes = new List<Hero> {
                new Hero
                {
                    Id = 1,
                    Name = "Spider-Man",
                    FullName = "Peter",
                    LastName = "Parker",
                    Place = "Queens"
                }
            };

            return Ok(heroes);
        }
    }
}
