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

        //GET /people
        [HttpGet]
        [Route("people")]
        public async Task<IEnumerable<PeopleDto>> GetPeopleAsync()
        {
            var people = (await repository.GetPeopleAsync())
                     .Select(people => people.peopleAsDto());
            return people;
        }
 
        //Post people
        [HttpPost]
        [Route("people")]
        public async Task<ActionResult<PeopleDto>> CreatePeopleAsync(PeopleDto peopleDto)
        {
            List<Result> peopleList = new List<Result>();
            int length = peopleDto.resultsDto.Count;
            int count = 0;     

            foreach (var person in peopleDto.resultsDto)
            {
                Result resultObt = new Result();
                if (length > count)
                {
                    resultObt.name = peopleDto.resultsDto[count].name;
                    resultObt.height = peopleDto.resultsDto[count].height;
                    resultObt.mass = peopleDto.resultsDto[count].mass;
                    resultObt.hair_color = peopleDto.resultsDto[count].hair_color;
                    resultObt.skin_color = peopleDto.resultsDto[count].skin_color;
                    resultObt.eye_color = peopleDto.resultsDto[count].eye_color;
                    resultObt.birth_year = peopleDto.resultsDto[count].birth_year;
                    resultObt.gender = peopleDto.resultsDto[count].gender;
                    resultObt.homeworld = peopleDto.resultsDto[count].homeworld;
                    resultObt.films = peopleDto.resultsDto[count].films;
                    resultObt.species = peopleDto.resultsDto[count].species;
                    resultObt.vehicles = peopleDto.resultsDto[count].vehicles;
                    resultObt.starships = peopleDto.resultsDto[count].starships;
                    resultObt.created = peopleDto.resultsDto[count].created;
                    resultObt.edited = peopleDto.resultsDto[count].edited;
                    resultObt.url = peopleDto.resultsDto[count].url;

                    peopleList.Add(resultObt);
                    count++;
                }

            }
            People people = new()
            {
                count = count,
                next = peopleDto.next,
                previous = peopleDto.previous,
                results = peopleList

            };
            await repository.CreatePeopleAsync(people);
            //return null;
            return CreatedAtAction(nameof(GetPeopleAsync), people.peopleAsDto());
        }

        //GET /items
        // [HttpGet]
        // [Route("people/search")]
        // public async Task<IEnumerable<PeopleDto>> GetPersonAsync(String name)
        // {
        //     var people = (await repository.GetPersonAsync(name))
        //              .Select(people => people.searchPersonAsDto(name));
        //     return people;
        // }
    }
}
