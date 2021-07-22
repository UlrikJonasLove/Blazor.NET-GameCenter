using gamecenter.Server.Data;
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
    [Authorize(Roles = "Admin")]
    public class GenresController : ControllerBase
    {
        private readonly AppDbContext context;

        public GenresController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Genre genre)
        {
            try
            {
                Genre existingGenre = context.Genres.FirstOrDefault(g => g.Name == genre.Name.ToLower());
                if(existingGenre != null)
                {
                    ModelState.AddModelError(string.Empty, "Genre already exist");
                }
                else if(ModelState.IsValid)
                {
                    context.Add(genre);
                    await context.SaveChangesAsync();
                    return Ok();
                }

                return Ok();
            
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            } 
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            try
            {
                return await context.Genres.ToListAsync();
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            }  
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> Get(int id)
        {
            try
            {
                var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
                if(genre == null) { return NotFound(); }
                return genre;
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            }  
        }

        [HttpPut]
        public async Task<ActionResult> Put(Genre genre)
        {
            try
            {
                context.Attach(genre).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return NoContent();
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
                var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
                if(genre == null) { return NotFound(); }

                context.Remove(genre);
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
