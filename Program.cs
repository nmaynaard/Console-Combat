using System;
using static System.Console;
using consoleCombat.Scenes;
using consoleCombat.Characters;

namespace consoleCombat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Title = "Console Combat";
            CursorVisible = false;
            Game game = new Game();

            // Disable While Running
            //game.Test();

            // Disable While Testing
            game.Start();
        }
    }
}