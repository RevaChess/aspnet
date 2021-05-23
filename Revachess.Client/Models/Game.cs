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

    }
}