using System;
using System.Threading;
using SnakeGamePro.Models;
using SnakeGamePro.Utilities;

namespace SnakeGamePro.Engine
{
    public class GameEngine
    {
        public event Action OnGameOver;

        private Snake snake;
        private Food food;
        private GameBoard board;
        private ScoreManager scoreManager;

        private bool running = true;
        private Direction direction = Direction.Right;

        public int Score { get; private set; }

        public GameEngine()
        {
            snake = new Snake();
            food = new Food();
            board = new GameBoard(40, 20);
            scoreManager = new ScoreManager();
        }

        enum Direction
        {
            Up,
            Down, Left, Right
        }

        public void Start()
        {
            Thread gameThread = new Thread(GameLoop);
            gameThread.Start();
        }

        private void GameLoop()
        {
            Random rand = new Random();

            food.Spawn(new Position(rand.Next(1, 30), rand.Next(1, 15)));

            while (running)
            {
                HandleInput();
                Update();
                Draw();

                Thread.Sleep(150);
            }
        }

        private void Update()
        {
            var head = snake.Body[0];

            Position newHead = new Position(head.X + 1, head.Y);

            if (!board[newHead.X, newHead.Y])
            {
                EndGame();
                return;
            }

            bool grow = newHead.X == food.Location.X &&
                        newHead.Y == food.Location.Y;

            if (grow)
            {
                Score += 10;

                Random rand = new Random();

                food.Spawn(new Position(rand.Next(1, 30), rand.Next(1, 15)));
            }

            snake.Move(newHead, grow);
        }

        private void Draw()
        {
            Console.Clear();

            foreach (var part in snake.Body)
            {
                Console.SetCursorPosition(part.X, part.Y);
                Console.Write("O");
            }

            Console.SetCursorPosition(food.Location.X, food.Location.Y);
            Console.Write("X");

            Console.SetCursorPosition(0, 0);
            Console.Write($"Score: {Score}");
        }

        private void EndGame()
        {
            running = false;

            scoreManager.SaveScore(Score);

            OnGameOver?.Invoke();
        }

        private void HandleInput()
        {
            if (!Console.KeyAvailable)
                return;

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    direction = Direction.Up;
                    break;

                case ConsoleKey.DownArrow:
                    direction = Direction.Down;
                    break;

                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    break;

                case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    break;

                case ConsoleKey.Spacebar:
                    PauseGame();
                    break;
            }
        }



    }
}