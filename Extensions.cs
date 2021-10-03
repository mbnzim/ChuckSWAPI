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

      ResultDto resultDto = new ResultDto();
      List<ResultDto> peopleList = new List<ResultDto>();
      //PeopleDto peopleDto = new PeopleDto();
      int count = 0;

      foreach (var person in people.results)
      {
        resultDto.name = people.results[count].name;
        resultDto.height = people.results[count].height;
        resultDto.mass = people.results[count].mass;
        resultDto.hair_color = people.results[count].hair_color;
        resultDto.skin_color =people.results[count].skin_color;
        resultDto.eye_color = people.results[count].eye_color;
        resultDto.birth_year =people.results[count].birth_year;
        resultDto.gender = people.results[count].gender;
        resultDto.homeworld = people.results[count].homeworld;
        resultDto.films = people.results[count].films;
        resultDto.species = people.results[count].species;
        resultDto.vehicles = people.results[count].vehicles;
        resultDto.starships = people.results[count].starships;
        resultDto.created = people.results[count].created;
        resultDto.edited =people.results[count].edited;
        resultDto.url = people.results[count].url;

        peopleList.Add(resultDto);
        count++;
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

  /*public static PeopleDto peopleAsDto(this PeopleDto peopleDto)
  {
    List<Result> peopleList = new List<Result>();
    int length = peopleDto.resultsDto.Count;
    int count = 0;

    Result resultObt = new Result();

    foreach (var person in peopleDto.resultsDto)
    {
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

    return new PeopleDto
    {
      count = count,
      next = peopleDto.next,
      previous = peopleDto.previous,
      resultsDto = peopleDto.resultsDto

    };

  }*/
}
