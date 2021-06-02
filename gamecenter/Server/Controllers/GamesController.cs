using AutoMapper;
using gamecenter.Server.Data;
using gamecenter.Server.Helpers;
using gamecenter.Server.Helpers.Interface;
using gamecenter.Shared.DTOs;
using gamecenter.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            try
            {
                if(!string.IsNullOrWhiteSpace(game.Poster))
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

                Game existingGame = context.Games.FirstOrDefault(g => g.Title == game.Title.ToLower());
                if(existingGame != null)
                {
                    ModelState.AddModelError(string.Empty, "This Game already exist");
                }
                else if(ModelState.IsValid)
                {
                    context.Add(game);
                    await context.SaveChangesAsync();
                    return game.Id;
                }
                return Ok();          
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            }  
        }

        [HttpPost("filter")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Game>>> Filter(GameFilterDTO gameFilterDto)
        {
            try
            {
                var gameQueryable = context.Games.AsQueryable();

                if(!string.IsNullOrWhiteSpace(gameFilterDto.Title))
                {
                    gameQueryable = gameQueryable.Where(x => x.Title.Contains(gameFilterDto.Title));
                }

                if(gameFilterDto.NewlyReleases)
                {
                    gameQueryable = gameQueryable.Where(x => x.NewlyReleases);
                }

                if(gameFilterDto.UpcomingReleases)
                {
                    var today = DateTime.Today;
                    gameQueryable = gameQueryable.Where(x => x.ReleaseDate > today);
                }

                if(gameFilterDto.GenreId != 0)
                {
                    gameQueryable = gameQueryable.Where(x => x.GamesGenres.Select(y => y.GenreId).Contains(gameFilterDto.GenreId));
                }

                await HttpContext.InsertPaginationParametersInResponse(gameQueryable, gameFilterDto.ItemsPerPage);
                var games = await gameQueryable.Paginate(gameFilterDto.Pagination).ToListAsync();

                return games;
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            } 
        }

      /*  [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Game>>> Get()
        {
            try
            {
                return await context.Games.ToListAsync();
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            }        
        } */

        //[HttpGet("{id}")] 
        //public async Task<ActionResult<Game>> Get(int id)
        //{
        //    var game = await context.Games.FirstOrDefaultAsync(x => x.Id == id);
        //    if(game == null) { return NotFound(); }
        //    return game;
        //}
        
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GameDetailDTO>> Get(int id)
        {
            try
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
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            }   
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IndexPageDTO>> Get()
        {
            var limit = 6;

            var newlyReleases = await context.Games
                .Where(x => x.NewlyReleases).Take(limit)
                .OrderByDescending(x => x.ReleaseDate)
                .ToListAsync();

            var todaysDate = DateTime.Today;

            var upcomingReleases = await context.Games
                .Where(x => x.ReleaseDate > todaysDate)
                .OrderBy(x => x.ReleaseDate).Take(limit)
                .ToListAsync();

            var response = new IndexPageDTO();
            response.NewlyReleases = newlyReleases;
            response.UpcomingReleases = upcomingReleases;

            return response;

        }

        [HttpGet("update/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UpdateGameDTO>> PutGet(int id)
        {
            try
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
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            }            
        }

        [HttpPut]
        public async Task<ActionResult> Put(Game game)
        {
            try
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
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            }           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var game = await context.Games.FirstOrDefaultAsync(x => x.Id == id);
                if(game == null) { return NotFound(); }

                context.Remove(game);
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            }   
        }
    }
}