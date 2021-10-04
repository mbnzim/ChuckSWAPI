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
  [Route("chuck")]
  public class CategoriesController : ControllerBase
  {
    private readonly IRepository repository;

    public CategoriesController(IRepository repository)
    {
      this.repository = repository;
    }
    //GET /items
    [HttpGet]
    public async Task<IEnumerable<CategoryDto>> GetCategoryAsync()
    {
      var categories = (await repository.GetCategoryAsync())
               .Select(category => category.AsDto());
      return categories;
    }


    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateCategoryAsync(CategoryDto categoryDto)
    {
      Categories category = new()
      {
        categories = categoryDto.categories
      };

      await repository.CreateCategoryAsync(category);
      return CreatedAtAction(nameof(GetCategoryAsync), category.AsDto());
    }

  }
}