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
    private const string collectionJokes = "jokes";

    private readonly IMongoCollection<Categories> categoriesCollection;
    private readonly IMongoCollection<People> peopleCollection;
    private readonly IMongoCollection<Jokes> jokesCollection;

    private readonly FilterDefinitionBuilder<Categories> filterBuilderCategories = Builders<Categories>.Filter;
    private readonly FilterDefinitionBuilder<People> filterBuilderPeople = Builders<People>.Filter;
    private readonly FilterDefinitionBuilder<Jokes> filterBuilder = Builders<Jokes>.Filter;

    public MongoDBRepository(IMongoClient mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(databaseName);
      categoriesCollection = database.GetCollection<Categories>(collectionCategory);
      peopleCollection = database.GetCollection<People>(collectionPeople);
      jokesCollection = database.GetCollection<Jokes>(collectionJokes);
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

    public async Task<IEnumerable<People>> GetPersonAsync(string name)
    {
      return await peopleCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<IEnumerable<Jokes>> GetJokesAsync(string name)
    {
      return await jokesCollection.Find(new BsonDocument()).ToListAsync();
    }
  }
}