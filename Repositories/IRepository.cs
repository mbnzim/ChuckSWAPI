using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using chuckswAPI.Dtos;
using chuckswAPI.Entities;

namespace chuckswAPI.Repositories
{
  public interface IRepository
  {

    Task<IEnumerable<Categories>> GetCategoryAsync();
    Task CreateCategoryAsync(Categories categories);
    Task<IEnumerable<People>> GetPeopleAsync();
    Task CreatePeopleAsync(People people);
  }
}