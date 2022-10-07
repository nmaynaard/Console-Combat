using System;
using static System.Console;

namespace consoleCombat // Note: actual namespace depends on the project name.
{
    class Game
    {
        public void Start()
        {
            Title = "Console Combat";
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            string prompt = @"     

            █████╗  █████╗ ███╗  ██╗ ██████  █████╗ ██╗     ███████╗  
           ██╔══██╗██╔══██╗████╗ ██║██╔════╝██╔══██╗██║     ██╔════╝  
           ██║  ╚═╝██║  ██║██╔██╗██║╚█████╗ ██║  ██║██║     █████╗  
           ██║  ██╗██║  ██║██║╚████║ ╚═══██╗██║  ██║██║     ██╔══╝  
           ╚█████╔╝╚█████╔╝██║ ╚███║██████╔╝╚█████╔╝███████╗███████╗  
            ╚════╝  ╚════╝ ╚═╝  ╚══╝╚═════╝  ╚════╝ ╚══════╝╚══════╝  

               █████╗  █████╗ ███╗   ███╗██████╗  █████╗ ████████╗
              ██╔══██╗██╔══██╗████╗ ████║██╔══██╗██╔══██╗╚══██╔══╝
              ██║  ╚═╝██║  ██║██╔████╔██║██████╦╝███████║   ██║
              ██║  ██╗██║  ██║██║╚██╔╝██║██╔══██╗██╔══██║   ██║
              ╚█████╔╝╚█████╔╝██║ ╚═╝ ██║██████╦╝██║  ██║   ██║
               ╚════╝  ╚════╝ ╚═╝     ╚═╝╚═════╝ ╚═╝  ╚═╝   ╚═╝
              
              
              ";
            string[] options = {
            "                                   𝐏𝐋𝐀𝐘",
            "                                   𝐀𝐁𝐎𝐔𝐓",
            "                                   𝐇𝐄𝐋𝐏",
            "                                   𝐄𝐗𝐈𝐓" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunFirstChoice();
                    break;
                case 1:
                    DisplayAbout();
                    break;
                case 2:
                    DisplayHelp();
                    break;
                case 3:
                    ExitGame();
                    break;
            }
        }

        private void ExitGame()
        {
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }
        private void DisplayAbout()
        {
            Clear();
            WriteLine("Game version: 1.0");
            WriteLine("A C# Console Game based on Combatting Opponents");
            WriteLine("https://github.com/nmaynaard/Console-Combat");
            ReadKey(true);
            RunMainMenu();
        }
        private void DisplayHelp()
        {
            Clear();
            WriteLine("Placeholder for tips on the game");
            ReadKey(true);
            RunMainMenu();
            // Add Tips on the game once created.
        }
        private void RunFirstChoice()
        {
            string prompt = "CHARACTER CREATION";
            string[] options = { "   New Character", "   Load Character", "   Back" };
            Menu createCharacterMenu = new Menu(prompt, options);
            int selectedIndex = createCharacterMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    NewCharacter();
                    break;
                case 1:
                    LoadCharacter();
                    break;
                case 2:
                    RunMainMenu();
                    break;
            }
        }
        private void LoadCharacter()
        {
            WriteLine("Loading Character...");
            ReadKey(true);
            RunMainMenu();
        }
        private void NewCharacter()
        {
            WriteLine("Creating Character...");
            ReadKey(true);
            RunMainMenu();
        }
    }
}