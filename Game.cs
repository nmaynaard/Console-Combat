using System;
using static System.Console;
using consoleCombat.Scenes;
using consoleCombat.Characters;
using consoleCombat.Items;

namespace consoleCombat // Note: actual namespace depends on the project name.
{
    class Game
    {

        public TitleScene titleScene;
        public AccountScene accountScene;
        public CharacterCreationScene characterCreationScene;
        public Player player;
        public Bulbasaur bulbasaur;
        public Charmander charmander;
        public Squirtle squirtle;
        private Item pokeball;
        private List<Character> enemies;
        private Character CurrentEnemy;
        public Game()
        {
            titleScene = new TitleScene(this);
            accountScene = new AccountScene(this);
            characterCreationScene = new CharacterCreationScene(this);
            bulbasaur = new Bulbasaur("Bulbasaur", 10, ConsoleColor.DarkYellow);
            charmander = new Charmander("Charmander", 10, ConsoleColor.Red);
            squirtle = new Squirtle("Squirtle", 10, ConsoleColor.Cyan);
            pokeball = new Item("Pokeball", 10);
            enemies = new List<Character>() { bulbasaur, charmander, squirtle };
        }
        public void Start()
        {
            titleScene.Run();
        }








        public void Test()
        {
            Write("Username:");
            string name = ReadLine();
            player = new Player(name, 40, ConsoleColor.Magenta);
            for (int i = 0; i < enemies.Count; i += 1)
            {
                CurrentEnemy = enemies[i];
                CurrentEnemy.DisplayInfo();
                ReadKey(true);
                Battle();
                if (player._isDead)
                {
                    WriteLine("You Died");
                    ReadKey(true);
                    break;
                }
                else
                {
                    WriteLine("You Survived");
                    ReadKey(true);
                }
            }

        }
        public void Battle()
        {
            Clear();
            while (player._isAlive && CurrentEnemy._isAlive)
            {
                player.HealthBar();
                CurrentEnemy.HealthBar();
                WriteLine();
                player.Attack(CurrentEnemy);
                WriteLine();
                ReadKey(true);
                if (player._isDead || CurrentEnemy._isDead) break;
                Clear();
                player.HealthBar();
                CurrentEnemy.HealthBar();
                WriteLine();
                CurrentEnemy.Attack(player);
                ReadKey(true);
            }
        }
    }
}