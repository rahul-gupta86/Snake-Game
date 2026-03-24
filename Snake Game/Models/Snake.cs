using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using SnakeGamePro.Interfaces;

namespace SnakeGamePro.Models
{
    public class Snake : IGameObject
    {
        private List<Position> body = new List<Position>();

        public IReadOnlyList<Position> Body => body;

        public Snake()
        {
            body.Add(new Position(10, 10));
        }

        public void Move(Position newHead, bool grow)
        {
            body.Insert(0, newHead);

            if (!grow)
                body.RemoveAt(body.Count - 1);
        }

        public bool CheckCollision(Position position)
        {
            foreach (var part in body)
            {
                if (part.X == position.X && part.Y == position.Y)
                    return true;
            }
            return false;
        }

        public void Update() { }

        public void Draw() { }
    }
}
