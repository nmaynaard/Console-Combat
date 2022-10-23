using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace consoleCombat.Helpers
{
    public class TownPlayer
    {
        public int x { get; set; }
        public int y { get; set; }
        public string PlayerMarker;
        private ConsoleColor PlayerColor;
        public TownPlayer(int initialX, int initialY)
        {
            x = initialX;
            y = initialY;
            PlayerMarker = "▲";
            PlayerColor = ConsoleColor.Magenta;
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