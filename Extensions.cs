using System.Collections.Generic;
using chuckswAPI.Dtos;
using chuckswAPI.Entities;

namespace chuckswAPI
{
  public static class Extensions
  {
    //CategoryDto
    public static CategoryDto AsDto(this Categories category)
    {
      return new CategoryDto
      {
        categories = category.categories
      };
    }

    //PeopleDto
    public static PeopleDto peopleAsDto(this People people)
    {
      List<ResultDto> peopleList = new List<ResultDto>();
      int count = 0;

      foreach (var person in people.results)
      {
        ResultDto resultDto = new ResultDto();
        resultDto.name = people.results[count].name;
        resultDto.height = people.results[count].height;
        resultDto.mass = people.results[count].mass;
        resultDto.hair_color = people.results[count].hair_color;
        resultDto.skin_color = people.results[count].skin_color;
        resultDto.eye_color = people.results[count].eye_color;
        resultDto.birth_year = people.results[count].birth_year;
        resultDto.gender = people.results[count].gender;
        resultDto.homeworld = people.results[count].homeworld;
        resultDto.films = people.results[count].films;
        resultDto.species = people.results[count].species;
        resultDto.vehicles = people.results[count].vehicles;
        resultDto.starships = people.results[count].starships;
        resultDto.created = people.results[count].created;
        resultDto.edited = people.results[count].edited;
        resultDto.url = people.results[count].url;

        peopleList.Add(resultDto);
        count++;
      }

      return new PeopleDto
      {
        count = people.count,
        next = people.next,
        previous = people.previous,
        endpoint = null,
        resultsDto = peopleList

      };
    }

    //Search person
    public static PeopleDto searchPersonAsDto(this People people, string name)
    {
      List<ResultDto> peopleList = new List<ResultDto>();
      int counter = 0;
      int index = 0;

      foreach (var person in people.results)
      {
        ResultDto resultDto = new ResultDto();
        if (name == people.results[index].name)
        {
          resultDto.name = people.results[index].name;
          resultDto.height = people.results[index].height;
          resultDto.mass = people.results[index].mass;
          resultDto.hair_color = people.results[index].hair_color;
          resultDto.skin_color = people.results[index].skin_color;
          resultDto.eye_color = people.results[index].eye_color;
          resultDto.birth_year = people.results[index].birth_year;
          resultDto.gender = people.results[index].gender;
          resultDto.homeworld = people.results[index].homeworld;
          resultDto.films = people.results[index].films;
          resultDto.species = people.results[index].species;
          resultDto.vehicles = people.results[index].vehicles;
          resultDto.starships = people.results[index].starships;
          resultDto.created = people.results[index].created;
          resultDto.edited = people.results[index].edited;
          resultDto.url = people.results[index].url;

          peopleList.Add(resultDto);
          counter++;
        }
        index++;
      }

      return new PeopleDto
      {
        count = counter,
        next = people.next,
        previous = people.previous,
        endpoint = "search/people",
        resultsDto = peopleList
      };
    }

    //Search jokes
    public static JokesDto searchJokesAsDto(this Jokes jokes, string name)
    {
      List<JokeDetailsDto> jokeList = new List<JokeDetailsDto>();
      int counter = 0;
      int index = 0;

      foreach (var person in jokes.result)
      {
        string jokeValue = jokes.result[index].value;
        JokeDetailsDto jokeDetailsDto = new JokeDetailsDto();

        if (jokeValue.Contains(name))
        {
          jokeDetailsDto.categories = jokes.result[index].categories;
          jokeDetailsDto.created_at = jokes.result[index].created_at;
          jokeDetailsDto.icon_url = jokes.result[index].icon_url;
          jokeDetailsDto.jokeId = jokes.result[index].jokeId;
          jokeDetailsDto.updated_at = jokes.result[index].updated_at;
          jokeDetailsDto.url = jokes.result[index].url;
          jokeDetailsDto.value = jokes.result[index].value;

          jokeList.Add(jokeDetailsDto);
          counter++;
        }
        index++;
      }

      return new JokesDto
      {
        total = counter,
        endpoint = "search/jokes",
        jokeDetailsDto = jokeList
      };
    }
  }
}
