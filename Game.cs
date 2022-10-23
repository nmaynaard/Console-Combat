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
        public TownScene townScene;
        public Game()
        {
            titleScene = new TitleScene(this);
            accountScene = new AccountScene(this);
            mainGameScene = new MainGameScene(this);
            fightScene = new FightScene(this);
            townScene = new TownScene(this);
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
            townScene.Run();
            Clear();
        }
    }
}

// Create levels the player can explore DONE
// Add random enemies to the map the player can fight DONE
// Random around the level DONE
// walk up to them and fight DONE
// Spawn into the world when creating a player level 1 etc. DONE
// add interiors to the map and spawn inside the home
// kill monsters to level up DONE
// add a shop 
// collect monsters
// Print a pokemon to random place on level; use townplayer.cs for reference but use random integer instead of specify DONE