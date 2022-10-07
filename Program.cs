using System;
using static System.Console;

namespace consoleCombat // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Title = "Console Combat";
            CursorVisible = false;
            Game game = new Game();
            game.Start();
        }
    }
}