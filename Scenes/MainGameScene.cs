using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleCombat.Helpers;
using consoleCombat;
using static System.Console;

namespace consoleCombat.Scenes
{
    class MainGameScene : Scene
    {
        public MainGameScene(Game game) : base(game)
        {
        }

        public override void Run()
        {
            ResetColor();
            WriteLine("Current Gold:");
            Write(MyGame.player.gold);
            string prompt = @$"
Gold: {MyGame.player.gold}
Experience: {MyGame.player.experience}
            
Main Menu:
            ";
            string[] options = { "Fight", "Shop", "Stats", "Inventory", "Log Out" };
            Menu createCharacterMenu = new Menu(prompt, options);
            int selectedIndex = createCharacterMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    MyGame.fightScene.Run();
                    break;
                case 1:
                    WriteLine("This is where you'll shop");
                    break;
                case 2:
                    WriteLine("This is where you'll see stats");
                    break;
                case 3:
                    WriteLine("This is where you'll see your inventory");
                    break;
                case 4:
                    Clear();
                    WriteLine("Logging Out..");
                    ReadKey(true);
                    MyGame.titleScene.Run();
                    break;

            }
        }
    }






}