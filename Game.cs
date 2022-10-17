using System;
using static System.Console;
using consoleCombat.Scenes;
using consoleCombat.Characters;
using consoleCombat.Items;

namespace consoleCombat
{
    class Game
    {

        public TitleScene titleScene;
        public AccountScene accountScene;
        public MainGameScene mainGameScene;
        public FightScene fightScene;
        public Player player;
        public List<Character> enemies;
        public Character CurrentEnemy;
        public Game()
        {
            titleScene = new TitleScene(this);
            accountScene = new AccountScene(this);
            mainGameScene = new MainGameScene(this);
            fightScene = new FightScene(this);
            Bulbasaur bulbasaur = new Bulbasaur("Bulbasaur", 10, ConsoleColor.DarkYellow);
            Charmander charmander = new Charmander("Charmander", 10, ConsoleColor.Red);
            Squirtle squirtle = new Squirtle("Squirtle", 10, ConsoleColor.Cyan);
            Item pokeball = new Item("Pokeball", 10);
            enemies = new List<Character>() { bulbasaur, charmander, squirtle };
            player = new Player(accountScene.username, 10, ConsoleColor.Magenta);
        }
        public void Start()
        {
            titleScene.Run();
        }

        public void Test()
        {
            mainGameScene.Run();
        }
    }
}