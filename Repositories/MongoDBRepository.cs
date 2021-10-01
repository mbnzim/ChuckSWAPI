using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using chuckswAPI.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace chuckswAPI.Repositories
{
  public class MongoDBRepository : IRepository
  {

    private const string databaseName = "chuckswDB";
    private const string collectionCategory = "categories";
    private const string collectionPeople = "people";

    private readonly IMongoCollection<Categories> categoriesCollection;
    private readonly IMongoCollection<People> peopleCollection;

    private readonly FilterDefinitionBuilder<Categories> filterBuilderCategories = Builders<Categories>.Filter;
    private readonly FilterDefinitionBuilder<People> filterBuilderPeople = Builders<People>.Filter;

    public MongoDBRepository(IMongoClient mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(databaseName);
      categoriesCollection = database.GetCollection<Categories>(collectionCategory);
      peopleCollection = database.GetCollection<People>(collectionPeople);
    }

    public async Task CreateCategoryAsync(Categories categories)
    {
      await categoriesCollection.InsertOneAsync(categories);
    }

    public async Task CreatePeopleAsync(People people)
    {
      await peopleCollection.InsertOneAsync(people);
    }

    public async Task<IEnumerable<Categories>> GetCategoryAsync()
    {
      return await categoriesCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<IEnumerable<People>> GetPeopleAsync()
    {
      return await peopleCollection.Find(new BsonDocument()).ToListAsync();
    }
  }
}