using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace consoleCombat.Helpers
{
    public class World
    {
        private string[,] Grid;
        private int Rows;
        private int Columns;
        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Columns = Grid.GetLength(1);
        }

        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }
        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    string element = Grid[y, x];

                    if (element == "X" || element == "H")
                    {
                        ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                    }
                    SetCursorPosition(x, y);
                    Write(element);
                }
            }
        }

        public bool IsPosWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Columns || y >= Rows)
            {
                return false;
            }
            return Grid[y, x] == " " || Grid[y, x] == "X" || Grid[y, x] == "H" || Grid[y, x] == "Q" || Grid[y, x] == "S";
        }
    }

}