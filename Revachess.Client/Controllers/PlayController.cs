using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Revachess.Client.Models;

namespace Revachess.Client.Controllers
{
  [Route("[controller]/[action]")]
  public class GameController : Controller
  {
    public IConfiguration _configuration;
    public GameController(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public async Task<List<Game>> GetGames()
    {
      var client = new HttpClient();
      var response = await client.GetAsync($"{_configuration["Services:webapi"]}/game");
      List<Game> result = null;

      if (response.IsSuccessStatusCode)
      {
        result = JsonConvert.DeserializeObject<List<Game>>(await response.Content.ReadAsStringAsync());
      }
      return result;
    }
    public async Task<List<User>> GetUsers()
    {
      var client = new HttpClient();
      var response = await client.GetAsync($"{_configuration["Services:webapi"]}/user");
      List<User> result = null;

      if (response.IsSuccessStatusCode)
      {
        result = JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync());
      }
      return result;
    }

    [HttpGet]
    [HttpPost]
    public IActionResult Index(UserViewModel user)
    {
      ViewBag.UserName = user.UserName;
      return Ok(user);
    }

  }
}