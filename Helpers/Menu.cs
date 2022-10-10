using System;
using static System.Console;
using consoleCombat.Scenes;
using consoleCombat.Characters;

namespace consoleCombat.Helpers
{
    class Menu
    {
        private int Index;
        private string[] Options;
        private string Prompt;

        public Menu(string prompt, string[] Options)
        {
            this.Prompt = prompt;
            this.Options = Options;
            Index = 0;

        }

        private void DisplayOptions()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine(Prompt);
            ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if (i == Index)
                {
                    prefix = "►";
                }
                else
                {
                    prefix = "  ";
                }

                WriteLine(prefix + currentOption);
            }
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    Index--;
                    if (Index == -1)
                    {
                        Index = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    Index++;
                    if (Index == Options.Length)
                    {
                        Index = 0;
                    }

                }
            } while (keyPressed != ConsoleKey.Enter);

            return Index;
        }
    }
}