using System;
using System.Collections.Generic;

namespace Revachess.Client.Models
{
  public class Game
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public User Player1 { get; set; }
    public User Player2 { get; set; }
    public User Winner { get; set; }
    public List<GameState> States { get; set; }
    public bool Started = false;
    public bool Ended = false;

    public Game()
    {
      States = new List<GameState>();
    }

    public Game(User CurrentUser, User Oponent)
    {
      States = new List<GameState>();
      Player1 = CurrentUser;
      Player2 = Oponent;
    }

  }
}