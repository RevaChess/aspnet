using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
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



    // [HttpGet]
    // [HttpPost]
    // public IActionResult AddUser(UserViewModel user)
    // {
    //   using (var client = new HttpClient())  
    //         {  
    //             User u = new User(){ UserName = user.UserName, Password = user.Password };  
    //             client.BaseAddress = new Uri("https://revachesswebapi.azurewebsites.net/play");  
    //             var response = client.PostAsJsonAsync("https://revachesswebapi.azurewebsites.net/play", u).Result;  
    //             if (response.IsSuccessStatusCode)  
    //             {  
    //               TempData["username"] = user.UserName;
    //                 return Ok("you are added to the database");
    //             }  
    //         }  
    //   return Ok("ERROR");
    // }


    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> Add(UserViewModel user)
    {
      List<User> Users = await GetUsers();
      foreach (var item in Users)
      {
        if (item.UserName == user.UserName) return View("register");
      }
      using (var client = new HttpClient())
      {
        User u = new User() { UserName = user.UserName, Password = user.Password };
        client.BaseAddress = new Uri("https://revachesswebapi.azurewebsites.net/play");
        var response = client.PostAsJsonAsync("https://revachesswebapi.azurewebsites.net/play", u).Result;
        if (response.IsSuccessStatusCode)
        {
          TempData["username"] = user.UserName;
          return Ok("you are added to the database and you are login");
        }
      }
      return Ok("ERROR");
    }

    public async Task<IActionResult> Get(UserViewModel user)
    {
      List<User> Users = await GetUsers();
      List<Game> Games = await GetGames();
      foreach (var item in Users)
      {
        if (item.UserName.ToLower().Equals(user.UserName.ToLower()) &&
        item.Password.Equals(user.Password))
        {
          TempData["username"] = item.UserName;
          TempData["user"] = item;
          Users.Remove(item);
          ViewBag.Users = Users;
          ViewBag.CurrentUser = item;
          List<Game> gametemp = new List<Game>();
          foreach (var game in Games)
          {
            if (game.Player1 == item || game.Player2 == item)
            {
              gametemp.Add(game);
            }
          }
          ViewBag.Games = gametemp;
          return View("gamelist");
        }
      }
      return View("index");
    }
    public async Task<IActionResult> makeGameAsync(string OponentUsername)
    {
      User CurrentUser = (User)TempData["user"];
      User Oponent;
      List<User> Users = await GetUsers();
      foreach (var user in Users)
      {
        if (user.UserName == OponentUsername)
        {
          Oponent = user;
          var Game = new Game(CurrentUser, Oponent);
          ViewBag.CurrentUser = CurrentUser;
          ViewBag.Oponent = Oponent;
          TempData["user"] = CurrentUser;
          TempData["oponent"] = Oponent;
          return View("play");
        }
      }
      return View("play");
    }


  }
}