using AutoMapper;
using gamecenter.Server.Data;
using gamecenter.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamecenter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {

        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public GamesController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Game game)
        {   
            context.Add(game);
            await context.SaveChangesAsync();
            return game.Id;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> Get()
        {
            return await context.Games.ToListAsync();
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Game>> Get(int id)
        {
            var game = await context.Games.FirstOrDefaultAsync(x => x.Id == id);
            if(game == null) { return NotFound(); }
            return game;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Game game)
        {
            var gameDb = await context.Games.FirstOrDefaultAsync(x => x.Id == game.Id);

            if(gameDb == null) { return NotFound(); }

            gameDb = mapper.Map(game, gameDb);

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var game = await context.Games.FirstOrDefaultAsync(x => x.Id == id);
            if(game == null) { return NotFound(); }

            context.Remove(game);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}