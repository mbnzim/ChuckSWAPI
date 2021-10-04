using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

public class Results
{
  public List<string> categories { get; set; }
  public string created_at { get; set; }
  public string icon_url { get; set; }
  public string jokeId { get; set; }
  public string updated_at { get; set; }
  public string url { get; set; }
  public string value { get; set; }
}

[BsonIgnoreExtraElements]
public class Jokes
{
  public int total { get; set; }
  public List<Results> result { get; set; }
}