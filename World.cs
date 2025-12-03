using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Maze_Final_Proj___ITEC_102
{
    class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = grid.GetLength(0);
            Cols = grid.GetLength(1);
        }

        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x, y);

                    if (element == "X")
                    {
                        ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                    }
                        Console.WriteLine(element);
                }
            }
        }

        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }

        public bool IsPositionWalkable(int x, int y)
        {
            //Check bounds first.
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }

            //Check if the position is walkable
            return Grid[y, x] == " " || Grid[y, x] == "X";


        }
    }
}
