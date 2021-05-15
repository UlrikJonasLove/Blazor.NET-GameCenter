using AutoMapper;
using gamecenter.Server.Data;
using gamecenter.Server.Helpers;
using gamecenter.Server.Helpers.Interface;
using gamecenter.Shared.DTOs;
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
        private readonly IFileStorageService fileStorageService;
        private readonly IMapper mapper;
        private string containerName = "games";

        public GamesController(AppDbContext context, IFileStorageService fileStorageService, IMapper mapper)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Game game)
        {
            if (!string.IsNullOrWhiteSpace(game.Poster))
            {
                var gamePoster = Convert.FromBase64String(game.Poster);
                game.Poster = await fileStorageService.SaveFile(gamePoster, ".jpg", containerName);
            }

            if(game.GamesPeople != null)
            {
                for(int i = 0; i < game.GamesPeople.Count; i++)
                {
                    game.GamesPeople[i].Order = i + 1;
                }
            }

            context.Add(game);
            await context.SaveChangesAsync();
            return game.Id;
        }

        [HttpPost("filter")]
        public async Task<ActionResult<List<Game>>> Filter(GameFilterDTO gameFilterDto)
        {
            var gameQueryable = context.Games.AsQueryable();

            if(!string.IsNullOrWhiteSpace(gameFilterDto.Title))
            {
                gameQueryable = gameQueryable.Where(x => x.Title.Contains(gameFilterDto.Title));
            }

            if(gameFilterDto.GenreId != 0)
            {
                gameQueryable = gameQueryable.Where(x => x.GamesGenres.Select(y => y.GenreId).Contains(gameFilterDto.GenreId));
            }

            await HttpContext.InsertPaginationParametersInResponse(gameQueryable, gameFilterDto.ItemsPerPage);
            var games = await gameQueryable.Paginate(gameFilterDto.Pagination).ToListAsync();

            return games;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> Get()
        {
            return await context.Games.ToListAsync();
        }

        //[HttpGet("{id}")] 
        //public async Task<ActionResult<Game>> Get(int id)
        //{
        //    var game = await context.Games.FirstOrDefaultAsync(x => x.Id == id);
        //    if(game == null) { return NotFound(); }
        //    return game;
        //}
        
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDetailDTO>> Get(int id)
        {
            var game = await context.Games.Where(x => x.Id == id)
                .Include(x => x.GamesGenres).ThenInclude(x => x.Genre)
                .Include(x => x.GamesPeople).ThenInclude(x => x.Person)
                .FirstOrDefaultAsync();

                if(game == null) { return NotFound(); }

                game.GamesPeople = game.GamesPeople.OrderBy(x => x.Order).ToList();

                var model = new GameDetailDTO();
                model.Game = game;
                model.Genres = game.GamesGenres.Select(x => x.Genre).ToList();
                model.PersonInGame = game.GamesPeople.Select(x => 
                    new Person 
                    {
                        Name = x.Person.Name,
                        Picture = x.Person.Picture,
                        RoleInGame = x.RoleOfGame,
                        Id = x.PersonId
                    }).ToList();

                return model;
        }

        [HttpGet("update/{id}")]
        public async Task<ActionResult<UpdateGameDTO>> PutGet(int id)
        {
            var gameActionResult = await Get(id);
            if(gameActionResult.Result is NotFoundResult) { return NotFound(); }

            var gameDetailDTO = gameActionResult.Value;
            var selectedGenresIds = gameDetailDTO.Genres.Select(x => x.Id).ToList();
            var notSelectedGenres = await context.Genres.Where(x => !selectedGenresIds.Contains(x.Id)).ToListAsync();

            var model = new UpdateGameDTO();
            model.Game = gameDetailDTO.Game;
            model.SelectedGenres = gameDetailDTO.Genres;
            model.NotSelectedGenres = notSelectedGenres;
            model.People = gameDetailDTO.PersonInGame;
            return model;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Game game)
        {
            var gameDb = await context.Games.FirstOrDefaultAsync(x => x.Id == game.Id);

            if(gameDb == null) { return NotFound(); }

            gameDb = mapper.Map(game, gameDb);

            if(!string.IsNullOrWhiteSpace(game.Poster))
            {
                var gamePoster = Convert.FromBase64String(game.Poster);
                gameDb.Poster = await fileStorageService.EditFile(gamePoster, "jpg", containerName, gameDb.Poster);
            }

            await context.Database.ExecuteSqlInterpolatedAsync($"delete from GamesPeople where GameId = {game.Id}; delete from GamesGenres where GameId = {game.Id}");

            if(game.GamesPeople != null)
            {
                for(int i = 0; i < game.GamesPeople.Count; i++)
                {
                    game.GamesPeople[i].Order = i + 1;
                }
            }

            gameDb.GamesPeople = game.GamesPeople;
            gameDb.GamesGenres= game.GamesGenres;
            
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