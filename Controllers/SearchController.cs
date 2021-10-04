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

  public class SearchController : ControllerBase
  {
    private readonly IRepository repository;

    public SearchController(IRepository repository)
    {
      this.repository = repository;
    }

    //GET /items
    // [HttpGet]
    // [Route("search/people")]
    // public async Task<IEnumerable<PeopleDto>> GetPersonAsync(String name)
    // {
    //   var people = (await repository.GetPersonAsync(name))
    //            .Select(people => people.searchPersonAsDto(name));
    //   return people;
    // }

    // [HttpGet]
    // [Route("search/jokes")]
    // public async Task<IEnumerable<JokesDto>> GetJokesAsync(String name)
    // {
    //   var jokes = (await repository.GetJokesAsync(name))
    //            .Select(jokes => jokes.searchJokesAsDto(name));
    //   return jokes;
    // }

    [HttpGet]
    [Route("search")]
    public async Task<Tuple<PeopleDto,JokesDto>>GetPersonAsync(String name, String joke)
    {
      var people = (await repository.GetPersonAsync(name))
               .Select(people => people.searchPersonAsDto(name));

      var jokes = (await repository.GetJokesAsync(joke))
      .Select(jokes => jokes.searchJokesAsDto(joke));


      return new Tuple<PeopleDto,JokesDto>(people.First(), jokes.First());
    }

  }
}
