using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SnakeGamePro.Interfaces;

namespace SnakeGamePro.Models
{
    public class Food : IGameObject
    {
        public Position Location { get; private set; }

        public void Spawn(Position position)
        {
            Location = position;
        }

        public void Update() { }

        public void Draw() { }
    }
}
