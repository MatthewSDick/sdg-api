using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Text.Json;


namespace sdg_api.Controllers
{
  [Route("[controller]")]
  [ApiController]

  public class MumblingController : ControllerBase
  {

    [HttpGet("{s}")]
    public string Mumbling(string s)
    {
      string result = "";
      int count = 0;
      foreach (char c in s.ToUpper())
      {
        Console.WriteLine(c);
        if (count != 0) result += "-";
        result += c + new String(char.ToLower(c), count);
        ++count;
      }

      var otherMumbling = new Mumbling();

      otherMumbling.Input = s;
      otherMumbling.Output = result;

      string json = JsonSerializer.Serialize(otherMumbling);

      return json;



    }

  }



}