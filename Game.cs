using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Maze_Final_Proj___ITEC_102
{
    class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        public void Start()
        {
            Title = "Maze Game - ITEC 102 Final Project";
            CursorVisible = false;

            string[,] grid ={
                { "■", "■", "■", "■", "■", "■", "■", "■", "■", "■" },
                { "■", " ", " ", "■", " ", "■", " ", " ", " ", "X" },
                { "■", "■", " ", "■", " ", "■", "■", "■", " ", "■" },
                { " ", " ", " ", " ", " ", " ", " ", " ", " ", "■" },
                { "■", " ", "■", "■", "■", "■", " ", "■", " ", "■" },
                { "■", " ", " ", " ", " ", " ", " ", "■", " ", "■" },
                { "■", "■", "■", "■", "■", "■", "■", "■", "■", "■" },
            };
            MyWorld = new World(grid);

            CurrentPlayer = new Player(0, 3);

            RunGameLoop();
        }

        private void DisplayIntro()
        {
            WriteLine("Welcome to the Maze Game!");
            WriteLine("\nInstructions:");
            WriteLine("Use the arrow keys to navigate through the maze.");
            WriteLine("Reach the exit marked with 'X' to win the game.");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\nPress any key to start...");
            ReadKey(true);
        }

        private void DisplayOutro()
        {
            Clear();
            WriteLine("Congratulations! You've reached the exit!");
            WriteLine("Thank you for playing the Maze Game.");
            WriteLine("Press any key to exit...");
            ReadKey(true);
        }

        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }

        private void HandlePlayerInput()
        {
            //input handling logic
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }

        private void RunGameLoop()
        {
            DisplayIntro();
            while (true)
            //game loop logic
            while (true)
            {
                //Draw Everything
                DrawFrame();

                //Check playerinput from keyboard and how pplayer moves
                HandlePlayerInput();

                //Check if the player has reached the exit or end the game
                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == "X")
                {
                    
                    break;
                }
                //Console chance to render
                System.Threading.Thread.Sleep(20);
            }
            DisplayOutro();
        }
        

    }
}
