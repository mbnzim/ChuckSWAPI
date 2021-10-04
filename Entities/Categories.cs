using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace chuckswAPI.Entities
{
  [BsonIgnoreExtraElements]
  public class Categories
  {
    public List<string> categories { get; set; }
  }
}