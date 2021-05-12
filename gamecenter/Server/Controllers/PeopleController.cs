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
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public PeopleController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Person person)
        {    
            context.Add(person);
            await context.SaveChangesAsync();
            return person.Id;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            return await context.People.ToListAsync();
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Person>> Get(int id)
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);
            if(person == null) { return NotFound(); }
            return person;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Person person)
        {
            var personDb = await context.People.FirstOrDefaultAsync(x => x.Id == person.Id);

            if(personDb == null) { return NotFound(); }

            personDb = mapper.Map(person, personDb);

            await context.SaveChangesAsync();
            return Ok();
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
