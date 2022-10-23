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
            player = new TownPlayer(1, 1);
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
                    WriteLine("A random monster appears...");
                    System.Threading.Thread.Sleep(1000);
                }
                else if ((player.x == monThree.x && player.y == monThree.y))
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("A random monster appears...");
                    System.Threading.Thread.Sleep(1000);
                    MyGame.fightScene.Run();
                }
                else if ((player.x == monTwo.x && player.y == monTwo.y))
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("A random monster appears...");
                    System.Threading.Thread.Sleep(1000);
                    MyGame.fightScene.Run();
                }
                else if ((player.x == monFour.x && player.y == monFour.y))
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("A random monster appears...");
                    System.Threading.Thread.Sleep(1000);
                    MyGame.fightScene.Run();
                }
                else if ((player.x == monFive.x && player.y == monFive.y))
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("A random monster appears...");
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
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("Returning to main Menu...");
                    System.Threading.Thread.Sleep(1000);
                    MyGame.accountScene.Register();
                    break;
                }
                System.Threading.Thread.Sleep(20);
            }
        }


    }
}