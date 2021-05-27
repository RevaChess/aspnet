using System;
using Revachess.Client.Models;
using Xunit;

namespace Revachess.Testing.Tests
{
  public class ModelsTests
  {
    [Fact]
    public void Test_UserNameNotNull()
    {
      var u = new User();
      u.UserName = "jo";

      Assert.NotNull(u.UserName);
    }


    [Fact]
    public void Test_Correct_Username()
    {
      var u = new User();
      u.UserName = "jo";
      var Expected = "jo";

      Assert.Equal(u.UserName, Expected);
    }

    [Fact]
    public void Test_UserPasswordNotNull()
    {
      var u = new User();
      u.Password = "pass";
      Assert.NotNull(u.Password);
    }
    [Fact]
    public void Test_Correct_Password()
    {
      var u = new User();
      u.Password = "pass";
      var Expected = "pass";
      Assert.Equal(u.Password, Expected);
    }

    [Fact]
    public void Test_GameName()
    {
      var g = new Game();
      g.Name = "jovsme";
      var Expected = "jovsme";
      Assert.Equal(g.Name, Expected);
    }

    [Fact]
    public void Test_GamePlayer1()
    {
      var g = new Game();
      var p1 = new User();
      g.Player1 = p1;

      Assert.NotNull(g.Player1);
    }

    [Fact]
    public void Test_GamePlayer2()
    {
      var p1 = new User();
      var p2 = new User();
      var game = new Game(p1, p2);

      Assert.NotNull(game);
    }

    [Fact]
    public void Test_GameState()
    {
      var s = new GameState();
      s.State = "stage1";
      Assert.NotNull(s);
    }
  }
}
