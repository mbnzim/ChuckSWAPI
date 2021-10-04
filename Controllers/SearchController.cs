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

    [HttpGet]
    public async Task<Tuple<PeopleDto, JokesDto>> GetPersonAsync(String name, String joke)
    {
      var people = (await repository.GetPersonAsync(name))
               .Select(people => people.searchPersonAsDto(name));

      var jokes = (await repository.GetJokesAsync(joke))
              .Select(jokes => jokes.searchJokesAsDto(joke));

      return new Tuple<PeopleDto, JokesDto>(people.First(), jokes.First());
    }

  }
}
