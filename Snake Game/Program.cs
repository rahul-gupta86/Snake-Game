using System;
using SnakeGamePro.Engine;

namespace SnakeGamePro
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;

            GameEngine engine = new GameEngine();

            engine.OnGameOver += () =>
            {
                Console.Clear();
                Console.WriteLine("Game Over!");
            };

            engine.Start();

            Console.ReadKey();
        }
    }
}