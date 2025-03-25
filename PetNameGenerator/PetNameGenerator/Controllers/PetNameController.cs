using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/petname")]
public class PetNameGeneratorController : ControllerBase
{
    private static readonly Dictionary<string, List<string>> names = new()
    {
        { "dog", new List<string> { "Buddy", "Max", "Charlie", "Rocky", "Rex" } },
        { "cat", new List<string> { "Whiskers", "Mittens", "Luna", "Simba", "Tiger" } },
        { "bird", new List<string> { "Tweety", "Sky", "Chirpy", "Raven", "Sunny" } }
    };

    [HttpPost("generate")]
    public IActionResult Generate([FromBody] PetNameRequest request)
    {
        if (!names.ContainsKey(request.AnimalType))
            return BadRequest(new { error = "Invalid AnimalType." });

        var rand = new Random();
        var nameList = names[request.AnimalType];
        string petName = nameList[rand.Next(nameList.Count)];

        if (request.TwoPart == true)
            petName += " " + nameList[rand.Next(nameList.Count)];

        return Ok(new { petName });
    }
}

public class PetNameRequest
{
    public string AnimalType { get; set; }
    public bool? TwoPart { get; set; }
}