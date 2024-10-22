﻿using Hero_API.Data;
using Hero_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
