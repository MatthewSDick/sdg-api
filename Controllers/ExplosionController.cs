using System;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace sdg_api.Controllers
{
  [Route("[controller]")]
  [ApiController]

  public class ExplosionController : ControllerBase
  {

    [HttpGet("{s}")]
    public string Explosion(string s)
    {

      string res = "";
      foreach (char i in s)
      {
        res += new String(i, int.Parse(i.ToString()));
      }

      var otherExplosion = new Explosion();

      otherExplosion.Input = s;
      otherExplosion.Output = res;

      var json = JsonSerializer.Serialize(otherExplosion);

      return json;
      //return res;
      // fdsafasdf


      /*
     var otherMumbling = new Mumbling();

      otherMumbling.Input = s;
      otherMumbling.Output = result;

      string json = JsonSerializer.Serialize(otherMumbling);
      */
    }

  }



}