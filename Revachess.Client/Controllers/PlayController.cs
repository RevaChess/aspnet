using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Revachess.Client.Models;

namespace Medialab.Client.Controllers
{
  [Route("[controller]")]
  public class PlayController : Controller
  {
    public IConfiguration _configuration;
    public PlayController(IConfiguration configuration)
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
    public async Task<List<Game>> GetUsers()
    {
      var client = new HttpClient();
      var response = await client.GetAsync($"{_configuration["Services:webapi"]}/user");
      List<Game> result = null;

      if (response.IsSuccessStatusCode)
      {
        result = JsonConvert.DeserializeObject<List<Game>>(await response.Content.ReadAsStringAsync());
      }
      return result;
    }
    
    [HttpGet]
    public async Task<ActionResult> Index()
    {
      var Games = await GetGames();
      ViewBag.Games = Games;
      return View("play");
    }

  }
}