using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chuckswAPI.Dtos;
using chuckswAPI.Entities;
using chuckswAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Result = chuckswAPI.Entities.Result;

namespace chuckswAPI.Controllers
{
  [ApiController]
  [Route("swapi")]
  public class PeopleController : ControllerBase
  {
    private readonly IRepository repository;

    public PeopleController(IRepository repository)
    {
      this.repository = repository;
    }
    //GET /items
    [HttpGet]
    public async Task<IEnumerable<PeopleDto>> GetPeopleAsync()
    {
      var people = (await repository.GetPeopleAsync())
               .Select(people => people.peopleAsDto());
      return people;
    }

    [HttpPost]
    public async Task<ActionResult<PeopleDto>> CreatePeopleAsync(PeopleDto peopleDto)
    {
      ResultDto resultDto = new ResultDto();
      List<Result> peopleList = new List<Result>();

      T CastObject<T>(object input)
      {
        return (T)input;
      }

      T ConvertObject<T>(object input)
      {
        return (T)Convert.ChangeType(input, typeof(T));
      }


      foreach (var person in peopleDto.resultsDto)
      {
        person.name = peopleDto.resultsDto[0].name;
        person.height = peopleDto.resultsDto[0].height;
        person.mass = peopleDto.resultsDto[0].mass;
        person.hair_color = peopleDto.resultsDto[0].hair_color;
        person.skin_color = peopleDto.resultsDto[0].skin_color;
        person.eye_color = peopleDto.resultsDto[0].eye_color;
        person.birth_year = peopleDto.resultsDto[0].birth_year;
        person.gender = peopleDto.resultsDto[0].gender;
        person.homeworld = peopleDto.resultsDto[0].homeworld;
        person.films = peopleDto.resultsDto[0].films;
        person.species = peopleDto.resultsDto[0].species;
        person.vehicles = peopleDto.resultsDto[0].vehicles;
        person.starships = peopleDto.resultsDto[0].starships;
        person.created = peopleDto.resultsDto[0].created;
        person.edited = peopleDto.resultsDto[0].edited;
        person.url = peopleDto.resultsDto[0].url;

        //ConvertObject<Result>(person);
       //Result r = CastObject<Result>(person);
        Result r = ConvertObject<Result>(person);
        peopleList.Add(r);

      }

      People people = new()
      {
        count = peopleDto.count,
        next = peopleDto.next,
        previous = peopleDto.previous,
        results = peopleList

      };


      await repository.CreatePeopleAsync(people);
      return CreatedAtAction(nameof(GetPeopleAsync), people.peopleAsDto());
    }
  }
}
