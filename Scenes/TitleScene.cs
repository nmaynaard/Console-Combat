using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using consoleCombat.Helpers;

namespace consoleCombat.Scenes
{
    class TitleScene : Scene
    {
        public TitleScene(Game game) : base(game)
        {
        }

        public override void Run()
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
            "                                   Register",
            "                                   Login",
            "                                   Help",
            "                                   Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    MyGame.accountScene.Register();
                    break;
                case 1:
                    MyGame.accountScene.Login();
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
        private void DisplayHelp()
        {
            Clear();
            WriteLine("Game version: 1.0");
            WriteLine("A C# Console Game based on Combatting Opponents");
            WriteLine("https://github.com/nmaynaard/Console-Combat");
            ReadKey(true);
            MyGame.titleScene.Run();
        }
    }
}
