using System;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace sdg_api
{

  [Route("[controller]")]
  [ApiController]

  public class CheckINController : ControllerBase
  {

    //[HttpGet("{newPerson}")]
    // public string aNewPerson(string newPerson)
    // {
    //   var Db = new DatabaseContext();
    //   var personToAdd = new CheckIn();
    //   personToAdd.Name = newPerson;
    //   Db.SaveNewPerson(personToAdd);
    //   return "";
    // }

    [HttpPost("{aNewPerson}")]

    public ActionResult VerifyAdded(string aNewPerson)
    {
      var Db = new DatabaseContext();
      var personToAdd = new CheckIn();
      personToAdd.Name = aNewPerson;
      Db.SaveNewPerson(personToAdd);

      var VerifyRecord = Db.CheckIns.First(x => x.Name == aNewPerson);

      var json = JsonSerializer.Serialize(VerifyRecord);

      var SavedResult = new ContentResult()
      {
        Content = json,
        ContentType = "application/json",
        StatusCode = 201
      };

      return SavedResult;
    }

    //[HttpGet]
    // public ActionResult PeopleCheckedIn()
    // {

    //var Db = new DatabaseContext();
    // foreach (var person in CheckIn)
    // {

    // }
    // var personToAdd = new CheckIn();
    // personToAdd.Name = aNewPerson;
    // Db.SaveNewPerson(personToAdd);

    // var VerifyRecord = Db.CheckIns.First(x => x.Name == aNewPerson);

    //var json = JsonSerializer.Serialize(CheckIn);

    // var SavedResult = new ContentResult()
    // {
    //   Content = json,
    //   ContentType = "application/json",
    //   StatusCode = 201
    // };

    //return "";



    //}

  }
}


