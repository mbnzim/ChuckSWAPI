using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
public class JokeDetailsDto
{
  public List<string> categories { get; set; }
  public string created_at { get; set; }
  public string icon_url { get; set; }
  public string jokeId { get; set; }
  public string updated_at { get; set; }
  public string url { get; set; }
  public string value { get; set; }
}

public class JokesDto
{
  public int total { get; set; }
  public string endpoint { get; set; }
  public List<JokeDetailsDto> jokeDetailsDto { get; set; }
}