using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace consoleCombat.Helpers
{
    public class SpawnMonster
    {
        public int x { get; set; }
        public int y { get; set; }
        private string PlayerMarker;
        private ConsoleColor PlayerColor;
        private Random rand;

        public SpawnMonster()
        {
            rand = new Random();
            x = rand.Next(1, 70);
            y = rand.Next(1, 20);
            PlayerMarker = "X";
            PlayerColor = ConsoleColor.Red;
        }

        public void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(x, y);
            Write(PlayerMarker);
            ResetColor();
        }
    }
}