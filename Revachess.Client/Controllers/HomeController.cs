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
  public class HomeController : Controller
  {
    public IConfiguration _configuration;
    public HomeController(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public async Task<IActionResult> Index()
    {
      var client = new HttpClient();
      var response = await client.GetAsync($"{_configuration["Services:webapi"]}/game");
      List<Game> result = null;

      if (response.IsSuccessStatusCode)
      {
        result = JsonConvert.DeserializeObject<List<Game>>(await response.Content.ReadAsStringAsync());
        ViewBag.Games = result;
      }
      return View("index");
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

    [Route("/register")]
    public IActionResult Register()
    {
      return View("register");
    }
  }
}