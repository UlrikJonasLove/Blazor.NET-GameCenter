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
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IFileStorageService fileStorageService;
        private readonly IMapper mapper;

        public PeopleController(AppDbContext context, IFileStorageService fileStorageService, IMapper mapper)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Person person)
        {    
            if(!string.IsNullOrWhiteSpace(person.Picture))
            {
                var personPicture = Convert.FromBase64String(person.Picture);
                person.Picture = await fileStorageService.SaveFile(personPicture, ".jpg", "people");
            }

            context.Add(person);
            await context.SaveChangesAsync();
            return person.Id;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get([FromQuery] PageDTO pageDto)
        {
            var queryable = context.People.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, pageDto.ItemsPerPage);

            return await queryable.Paginate(pageDto).ToListAsync();
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Person>> Get(int id)
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);
            if(person == null) { return NotFound(); }
            return person;
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<List<Person>>> FilterByName(string searchText)
        {
            if(string.IsNullOrWhiteSpace(searchText)) { return new List<Person>(); }
            return await context.People.Where(x => x.Name.Contains(searchText)).Take(5).ToListAsync();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Person person)
        {
            var personDb = await context.People.FirstOrDefaultAsync(x => x.Id == person.Id);

            if(personDb == null) { return NotFound(); }

            personDb = mapper.Map(person, personDb);

            if(!string.IsNullOrWhiteSpace(person.Picture))
            {
                var personPicture = Convert.FromBase64String(person.Picture);
                personDb.Picture = await fileStorageService.EditFile(personPicture, "jpg", "people", personDb.Picture);
            }

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);
            if(person == null) { return NotFound(); }

            context.Remove(person);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
