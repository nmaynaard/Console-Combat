using System;
using static System.Console;

namespace consoleCombat // Note: actual namespace depends on the project name.
{
    class Game
    {
        public void Start()
        {
            WriteLine();
            WriteLine("Starting...");
            WriteLine();
            ConsoleKeyInfo keyPressed = ReadKey();
            if (keyPressed.Key == ConsoleKey.Enter)
            {
                WriteLine();
                WriteLine("You Pressed Enter");
                WriteLine();
            }
            else
            {
                WriteLine("You Pressed Exit");
            }

            ReadKey(true);
        }
    }
}