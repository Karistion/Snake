using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 50;
            Console.BufferHeight = 30;
            Console.BufferWidth = 50;

            int x1 = 25;
            int y1 = 15;
            int foodX = 0;
            int foodY = 0;
            int score = 0;

            List<int> xCoordinates = new List<int>();
            List<int> yCoordinates = new List<int>();

            xCoordinates.Add(x1);
            yCoordinates.Add(y1);

            Random randomNumberGenerator = new Random();
            foodX = randomNumberGenerator.Next(0, Console.WindowWidth);
            foodY = randomNumberGenerator.Next(0, Console.WindowHeight);

            while (true)
            {
                Console.Clear();

                for (int i = 0; i < xCoordinates.Count; i++)
                {
                    Console.SetCursorPosition(xCoordinates[i], yCoordinates[i]);
                    Console.Write("*");
                }

                Console.SetCursorPosition(foodX, foodY);
                Console.Write("@");

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Score: " + score);

                ConsoleKeyInfo userInput = Console.ReadKey();

                int x2 = xCoordinates[xCoordinates.Count - 1];
                int y2 = yCoordinates[yCoordinates.Count - 1];

                for (int i = xCoordinates.Count - 1; i > 0; i--)
                {
                    xCoordinates[i] = xCoordinates[i - 1];
                    yCoordinates[i] = yCoordinates[i - 1];
                }

                switch (userInput.Key)
                {
                    case ConsoleKey.LeftArrow:
                        x1--;
                        break;
                    case ConsoleKey.RightArrow:
                        x1++;
                        break;
                    case ConsoleKey.UpArrow:
                        y1--;
                        break;
                    case ConsoleKey.DownArrow:
                        y1++;
                        break;
                }

                xCoordinates[0] = x1;
                yCoordinates[0] = y1;

                if (x1 == foodX && y1 == foodY)
                {
                    score++;
                    xCoordinates.Add(x2);
                    yCoordinates.Add(y2);
                    foodX = randomNumberGenerator.Next(0, Console.WindowWidth);
                    foodY = randomNumberGenerator.Next(0, Console.WindowHeight);
                }

                if (x1 < 0 || x1 >= Console.WindowWidth ||
                    y1 < 0 || y1 >= Console.WindowHeight)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Game Over!");
                    Console.WriteLine("Final Score: " + score);
                    break;
                }
            }
        }
    }
}
