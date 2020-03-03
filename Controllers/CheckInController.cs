using System;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace sdg_api
{

  [Route("[controller]")]
  [ApiController]

  public class CheckINController : ControllerBase
  {

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

    [HttpGet]
    public ActionResult PeopleCheckedIn()
    {

      var Db = new DatabaseContext();
      var listOfPeople = new List<CheckIn>();
      listOfPeople = Db.GetPeople();

      var json = JsonSerializer.Serialize(listOfPeople);

      var SavedResult = new ContentResult()
      {
        Content = json,
        ContentType = "application/json",
        StatusCode = 201
      };

      return SavedResult;
    }

  }
}


