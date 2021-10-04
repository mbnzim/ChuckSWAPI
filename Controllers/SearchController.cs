using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chuckswAPI.Dtos;
using chuckswAPI.Entities;
using chuckswAPI.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace chuckswAPI.Controllers
{
    [ApiController]
    [Route("search")]
    public class SearchController : ControllerBase
    {
        private readonly IRepository repository;

        public SearchController(IRepository repository)
        {
            this.repository = repository;
        }

        //GET /items
        [HttpGet]
        public async Task<IEnumerable<PeopleDto>> GetPersonAsync(String name)
        {
            var people = (await repository.GetPersonAsync(name))
                     .Select(people => people.searchPersonAsDto(name));
            return people;
        }
    }
}
