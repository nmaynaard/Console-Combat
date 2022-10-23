using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleCombat.Helpers;
using static System.Console;

namespace consoleCombat.Scenes
{
    class TownScene : Scene
    {
        private string[,] Grid;
        private int Rows;
        private int Columns;
        private World town;
        private TownPlayer player;
        private ConsoleKey key;
        private SpawnMonster monOne;
        private SpawnMonster monTwo;
        private SpawnMonster monThree;
        private SpawnMonster monFour;
        private SpawnMonster monFive;
        public TownScene(Game game) : base(game)
        {

        }


        public override void Run()
        {
            Clear();
            string[,] grid = LevelParser.ParseFileToArray("ttown.txt");

            town = new World(grid);
            player = new TownPlayer(52, 10);
            monOne = new SpawnMonster();
            monTwo = new SpawnMonster();
            monThree = new SpawnMonster();
            monFour = new SpawnMonster();
            monFive = new SpawnMonster();
            GameLoop();


            ReadKey(true);
        }

        private void DrawFrame()
        {
            Clear();
            town.Draw();
            player.Draw();
            monOne.Draw();
            monTwo.Draw();
            monThree.Draw();
            monFour.Draw();
            monFive.Draw();

        }

        private void HandlePlayerInput()
        {

            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (town.IsPosWalkable(player.x, player.y - 1))
                    {
                        player.PlayerMarker = "▲";
                        player.y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (town.IsPosWalkable(player.x, player.y + 1))
                    {
                        player.PlayerMarker = "▼";
                        player.y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (town.IsPosWalkable(player.x - 1, player.y))
                    {
                        player.PlayerMarker = "◄";
                        player.x -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (town.IsPosWalkable(player.x + 1, player.y))
                    {
                        player.PlayerMarker = "►";
                        player.x += 1;
                    }
                    break;
                default:
                    break;
            }
        }

        private void DisplayStats()
        {
            Clear();
            WriteLine($"Experience: {MyGame.player.experience}");
            WriteLine($"Gold: {MyGame.player.gold}");
            WriteLine($"Lvl: {MyGame.player._level}");
            ReadKey(true);
            Run();
        }
        private void Help()
        {
            Clear();
            WriteLine(@$"
Welcome to Console Combat, you begin in the world as a Level 1 Trainer 
and must battle creatures that randomly spawn within town by heading
to one of the red question marks located within the town. Battling and 
beating the creature in battle will allow you to gain experience, gold
and develop your character to become stronger and allow you battle 
stronger creatures. You can move around the town by using the Arrow keys 
and must travel to either one of the red question marks located within the 
map to battle a creature or to one of the letters located at each of the 
points of interest.

HOME is where your trainer lives, you can view your stats here and eventually
upgrade your trainer. The HELP house is where you currently are here you 
ill find out about anything within town and what it does. 
HOSPITAL is where you can heal your trainer and subsequent characters. 
INVENTORY is your storage, here you can see which items you currently own and 
can see a list of creatures you have captured. Lastly, STORE is where you can 
buy and sell items to help you gain money, experience, abilities and much more.


");
            ReadKey(true);
            Run();
        }
        private void GameLoop()
        {
            while (true)
            {
                DrawFrame();
                HandlePlayerInput();
                string elementAtPlayerPos = town.GetElementAt(player.x, player.y);

                if ((player.x == monOne.x && player.y == monOne.y))
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("A random pokemon appears...");
                    System.Threading.Thread.Sleep(1000);
                }
                else if ((player.x == monThree.x && player.y == monThree.y))
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("A random pokemon appears...");
                    System.Threading.Thread.Sleep(1000);
                    MyGame.fightScene.Run();
                }
                else if ((player.x == monTwo.x && player.y == monTwo.y))
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("A random pokemon appears...");
                    System.Threading.Thread.Sleep(1000);
                    MyGame.fightScene.Run();
                }
                else if ((player.x == monFour.x && player.y == monFour.y))
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("A random pokemon appears...");
                    System.Threading.Thread.Sleep(1000);
                    MyGame.fightScene.Run();
                }
                else if ((player.x == monFive.x && player.y == monFive.y))
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("A random pokemon appears...");
                    System.Threading.Thread.Sleep(1000);
                    MyGame.fightScene.Run();
                }

                if (elementAtPlayerPos == "X")
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("Returning to main Menu...");
                    System.Threading.Thread.Sleep(1000);
                    MyGame.titleScene.Run();
                    break;
                }
                if (elementAtPlayerPos == "H")
                {
                    Clear();
                    DisplayStats();
                    break;
                }
                if (elementAtPlayerPos == "Q")
                {
                    Clear();
                    Help();
                    break;
                }
                if (elementAtPlayerPos == "S")
                {
                    Clear();
                    MyGame.player.PlayerHeal();
                    WriteLine("You've healed yourself back to full health");
                    System.Threading.Thread.Sleep(2000);
                    Run();
                    break;
                }
                System.Threading.Thread.Sleep(20);
            }
        }


    }
}