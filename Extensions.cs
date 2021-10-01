


using System.Collections.Generic;
using chuckswAPI.Dtos;
using chuckswAPI.Entities;

namespace chuckswAPI
{
  public static class Extensions
  {
    public static CategoryDto AsDto(this Categories category)
    {
      return new CategoryDto
      {
        categories = category.categories
      };
    }

    public static PeopleDto peopleAsDto(this People people)
    {

      ResultDto result = new ResultDto();
      List<ResultDto> peopleList = new List<ResultDto>();

      foreach (var person in peopleList)
      {
        person.name = result.name;
        person.height = result.height;
        person.mass = result.mass;
        person.hair_color = result.hair_color;
        person.skin_color = result.skin_color;
        person.eye_color = result.eye_color;
        person.birth_year = result.birth_year;
        person.gender = result.gender;
        person.homeworld = result.homeworld;
        person.films = result.films;
        person.species = result.species;
        person.vehicles = result.vehicles;
        person.starships = result.starships;
        person.created = result.created;
        person.edited = result.edited;
        person.url = result.url;

        peopleList.Add(person);
      }

      return new PeopleDto
      {
        count = people.count,
        next = people.next,
        previous = people.previous,
        resultsDto = peopleList
      };
    }
  }
}